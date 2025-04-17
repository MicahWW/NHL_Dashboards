using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using NHL_Dashboards.Models;

namespace NHL_Dashboards.Controllers.Api.Standings;

[ApiController]
[Route("[controller]")]
public class PlayoffsApiController(ILogger<PlayoffsApiController> logger, IHttpClientFactory httpClientFactory) : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger<PlayoffsApiController> _logger = logger;

    [HttpGet]
    [OpenApiTag("Standings")]
    [ProducesResponseType<PlayoffsStandingsApiModel>(StatusCodes.Status200OK)]
    public IActionResult Get([FromQuery] string year = "")
    {
        string testData = "{\"series\":[{\"topTeam\":{\"id\":13,\"abbr\":\"FLA\",\"wins\":4,\"seedRank\":1,\"seedAbbr\":\"D1\"},\"botTeam\":{\"id\":14,\"abbr\":\"TBL\",\"wins\":1,\"seedRank\":4,\"seedAbbr\":\"WC1\"},\"conference\":1,\"seriesLetter\":\"A\"},{\"topTeam\":{\"id\":6,\"abbr\":\"BOS\",\"wins\":4,\"seedRank\":2,\"seedAbbr\":\"D2\"},\"botTeam\":{\"id\":10,\"abbr\":\"TOR\",\"wins\":3,\"seedRank\":3,\"seedAbbr\":\"D3\"},\"conference\":1,\"seriesLetter\":\"B\"},{\"topTeam\":{\"id\":3,\"abbr\":\"NYR\",\"wins\":4,\"seedRank\":1,\"seedAbbr\":\"D1\"},\"botTeam\":{\"id\":15,\"abbr\":\"WSH\",\"wins\":0,\"seedRank\":4,\"seedAbbr\":\"WC2\"},\"conference\":1,\"seriesLetter\":\"C\"},{\"topTeam\":{\"id\":12,\"abbr\":\"CAR\",\"wins\":4,\"seedRank\":2,\"seedAbbr\":\"D2\"},\"botTeam\":{\"id\":2,\"abbr\":\"NYI\",\"wins\":1,\"seedRank\":3,\"seedAbbr\":\"D3\"},\"conference\":1,\"seriesLetter\":\"D\"},{\"topTeam\":{\"id\":25,\"abbr\":\"DAL\",\"wins\":4,\"seedRank\":1,\"seedAbbr\":\"D1\"},\"botTeam\":{\"id\":54,\"abbr\":\"VGK\",\"wins\":3,\"seedRank\":4,\"seedAbbr\":\"WC2\"},\"conference\":0,\"seriesLetter\":\"E\"},{\"topTeam\":{\"id\":52,\"abbr\":\"WPG\",\"wins\":1,\"seedRank\":2,\"seedAbbr\":\"D2\"},\"botTeam\":{\"id\":21,\"abbr\":\"COL\",\"wins\":4,\"seedRank\":3,\"seedAbbr\":\"D3\"},\"conference\":0,\"seriesLetter\":\"F\"},{\"topTeam\":{\"id\":23,\"abbr\":\"VAN\",\"wins\":4,\"seedRank\":1,\"seedAbbr\":\"D1\"},\"botTeam\":{\"id\":18,\"abbr\":\"NSH\",\"wins\":2,\"seedRank\":4,\"seedAbbr\":\"WC1\"},\"conference\":0,\"seriesLetter\":\"G\"},{\"topTeam\":{\"id\":22,\"abbr\":\"EDM\",\"wins\":4,\"seedRank\":2,\"seedAbbr\":\"D2\"},\"botTeam\":{\"id\":26,\"abbr\":\"LAK\",\"wins\":1,\"seedRank\":3,\"seedAbbr\":\"D3\"},\"conference\":0,\"seriesLetter\":\"H\"},{\"topTeam\":{\"id\":13,\"abbr\":\"FLA\",\"wins\":4,\"seedRank\":1,\"seedAbbr\":\"D1\"},\"botTeam\":{\"id\":6,\"abbr\":\"BOS\",\"wins\":2,\"seedRank\":2,\"seedAbbr\":\"D2\"},\"conference\":1,\"seriesLetter\":\"I\"},{\"topTeam\":{\"id\":3,\"abbr\":\"NYR\",\"wins\":4,\"seedRank\":1,\"seedAbbr\":\"D1\"},\"botTeam\":{\"id\":12,\"abbr\":\"CAR\",\"wins\":2,\"seedRank\":2,\"seedAbbr\":\"D2\"},\"conference\":1,\"seriesLetter\":\"J\"},{\"topTeam\":{\"id\":25,\"abbr\":\"DAL\",\"wins\":4,\"seedRank\":1,\"seedAbbr\":\"D1\"},\"botTeam\":{\"id\":21,\"abbr\":\"COL\",\"wins\":2,\"seedRank\":3,\"seedAbbr\":\"D3\"},\"conference\":0,\"seriesLetter\":\"K\"},{\"topTeam\":{\"id\":23,\"abbr\":\"VAN\",\"wins\":3,\"seedRank\":1,\"seedAbbr\":\"D1\"},\"botTeam\":{\"id\":22,\"abbr\":\"EDM\",\"wins\":4,\"seedRank\":2,\"seedAbbr\":\"D2\"},\"conference\":0,\"seriesLetter\":\"L\"},{\"topTeam\":{\"id\":13,\"abbr\":\"FLA\",\"wins\":4,\"seedRank\":1,\"seedAbbr\":\"D1\"},\"botTeam\":{\"id\":3,\"abbr\":\"NYR\",\"wins\":2,\"seedRank\":1,\"seedAbbr\":\"D1\"},\"conference\":1,\"seriesLetter\":\"M\"},{\"topTeam\":{\"id\":25,\"abbr\":\"DAL\",\"wins\":2,\"seedRank\":1,\"seedAbbr\":\"D1\"},\"botTeam\":{\"id\":22,\"abbr\":\"EDM\",\"wins\":4,\"seedRank\":2,\"seedAbbr\":\"D2\"},\"conference\":0,\"seriesLetter\":\"N\"},{\"topTeam\":{\"id\":22,\"abbr\":\"EDM\",\"wins\":3,\"seedRank\":2,\"seedAbbr\":\"D2\"},\"botTeam\":{\"id\":13,\"abbr\":\"FLA\",\"wins\":4,\"seedRank\":1,\"seedAbbr\":\"D1\"},\"conference\":2,\"seriesLetter\":\"O\"}]}";
        return Content(testData, "application/json");

    }
}