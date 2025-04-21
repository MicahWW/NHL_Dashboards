using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using NHL_Dashboards.Models;
using NSwag.Annotations;
using Microsoft.Graph;

namespace NHL_Dashboards.Controllers.Api;

[ApiController]
[Route("[controller]")]
public class SeatingApiController(ILogger<SeatingApiController> logger, IConfiguration configuration) : ControllerBase
{
    private readonly ILogger<SeatingApiController> _logger = logger;
    private readonly IConfiguration _configuration = configuration;

    [HttpGet]
    [OpenApiTag("Seating")]
    [ProducesResponseType<SeatingApiModel>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync()
    {
        #region Login to Graph
        var clientId = _configuration["seating-clientId"];
        var clientSecret = _configuration["seating-clientSecret"];
        var tenantId = _configuration["seating-tenantId"];

        var ClientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
        // Use the default scope, which will request the scopes
        // configured on the app registration
        var graphClient = new GraphServiceClient(ClientSecretCredential,
            ["https://graph.microsoft.com/.default"]);
        #endregion
        #region Getting the data from Sharepoint
        Microsoft.Graph.Models.ListItemCollectionResponse? result;
        // This try catch will catch when the graphClient didn't authenticate properly
        try
        {
            result = await graphClient.Sites["b2dc9b62-eb8b-48fd-979b-bb5361e769fe"].Lists["7A757685-2077-4499-BBBE-DC9E45ECE810"].Items.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Expand = ["fields($select=Title,Location)"];
            });
        }
        catch
        {
            _logger.LogError("Couldn't access the Sharepoint List");
            return Problem
            (
                title: "Getting Seating data from Sharepoint",
                detail: "Couldn't access the Sharepoint List",
                statusCode: 500
            );
        }

        if (result == null || result.Value == null || result.Value.Count == 0)
        {
            _logger.LogError("No data found in the Sharepoint List");
            return Problem
            (
                title: "Reading Seating data from Sharepoint",
                detail: "No data found in the Sharepoint List",
                statusCode: 500
            );
        }
        #endregion
        #region  Formatting the data
        var output = new SeatingApiModel();

        foreach (var item in result.Value)
        {
            if (item.Fields == null || item.Fields.AdditionalData == null || item.Fields.AdditionalData["Location"] == null)
            {
                _logger.LogError("Reading item fields from Sharepoint failed");
                return Problem
                (
                    title: "Reading item fields from Sharepoint",
                    detail: "Reading item fields from Sharepoint failed",
                    statusCode: 500
                );
            }

            // if there is no title then it means it was blank, that is to be expected as not always will that info be filled
            if (item.Fields.AdditionalData["Location"].ToString()!.Contains("Booth"))
            {
                output.Booths.Add(item.Fields.AdditionalData.TryGetValue("Title", out object? value) ? value.ToString()! : "");
            }
            else if (item.Fields.AdditionalData["Location"].ToString()!.Contains("Seat"))
            {
                output.Seats.Add(item.Fields.AdditionalData.TryGetValue("Title", out object? value) ? value.ToString()! : "");
            }
            else if (item.Fields.AdditionalData["Location"].ToString()!.Contains("Aux seat"))
            {
                output.AuxSeats.Add(item.Fields.AdditionalData.TryGetValue("Title", out object? value) ? value.ToString()! : "");
            }
            else if (item.Fields.AdditionalData["Location"].ToString()!.Equals("WiFi network"))
            {
                output.Other.WiFiNetwork = item.Fields.AdditionalData.TryGetValue("Title", out object? value) ? value.ToString()! : "";
            }
            else if (item.Fields.AdditionalData["Location"].ToString()!.Equals("WiFi password"))
            {
                output.Other.WiFiPassword = item.Fields.AdditionalData.TryGetValue("Title", out object? value) ? value.ToString()! : "";
            }
            else if (item.Fields.AdditionalData["Location"].ToString()!.Equals("Opponent"))
            {
                output.Other.Opponent = item.Fields.AdditionalData.TryGetValue("Title", out object? value) ? value.ToString()! : "";
            }
            else if (item.Fields.AdditionalData["Location"].ToString()!.Equals("Use Aux screen #1?"))
            {
                item.Fields.AdditionalData.TryGetValue("Title", out object? rawValue);
                if (rawValue != null && rawValue.ToString() != null)
                {
                    var value = rawValue.ToString()!.ToLower();
                    if (value.Equals("y") || value.Equals("yes") || value.Equals("true"))
                    {
                        output.Other.UseAuxScreenOne = true;
                    }
                    // UseAuxScreenOne is false by default, so no need to set it to false again
                }
            }
            else if (item.Fields.AdditionalData["Location"].ToString()!.Equals("Use both Aux screens?"))
            {
                item.Fields.AdditionalData.TryGetValue("Title", out object? rawValue);
                if (rawValue != null && rawValue.ToString() != null)
                {
                    var value = rawValue.ToString()!.ToLower();
                    if (value.Equals("y") || value.Equals("yes") || value.Equals("true"))
                    {
                        output.Other.UseBothAuxScreens = true;
                    }
                    // UseBothAuxScreens is false by default, so no need to set it to false again
                }
            }
        }
        #endregion

        return Ok(output);
    }
}