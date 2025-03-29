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
        string testData = "{\"series\":[{\"topTeam\":{\"id\":13,\"abbrev\":\"FLA\",\"wins\":4,\"seedRank\":1,\"seedAbbrev\":\"D1\"},\"botTeam\":{\"id\":14,\"abbrev\":\"TBL\",\"wins\":1,\"seedRank\":4,\"seedAbbrev\":\"WC1\"},\"conference\":1,\"seriesLetter\":\"A\"},{\"topTeam\":{\"id\":6,\"abbrev\":\"BOS\",\"wins\":4,\"seedRank\":2,\"seedAbbrev\":\"D2\"},\"botTeam\":{\"id\":10,\"abbrev\":\"TOR\",\"wins\":3,\"seedRank\":3,\"seedAbbrev\":\"D3\"},\"conference\":1,\"seriesLetter\":\"B\"},{\"topTeam\":{\"id\":3,\"abbrev\":\"NYR\",\"wins\":4,\"seedRank\":1,\"seedAbbrev\":\"D1\"},\"botTeam\":{\"id\":15,\"abbrev\":\"WSH\",\"wins\":0,\"seedRank\":4,\"seedAbbrev\":\"WC2\"},\"conference\":1,\"seriesLetter\":\"C\"},{\"topTeam\":{\"id\":12,\"abbrev\":\"CAR\",\"wins\":4,\"seedRank\":2,\"seedAbbrev\":\"D2\"},\"botTeam\":{\"id\":2,\"abbrev\":\"NYI\",\"wins\":1,\"seedRank\":3,\"seedAbbrev\":\"D3\"},\"conference\":1,\"seriesLetter\":\"D\"},{\"topTeam\":{\"id\":25,\"abbrev\":\"DAL\",\"wins\":4,\"seedRank\":1,\"seedAbbrev\":\"D1\"},\"botTeam\":{\"id\":54,\"abbrev\":\"VGK\",\"wins\":3,\"seedRank\":4,\"seedAbbrev\":\"WC2\"},\"conference\":0,\"seriesLetter\":\"E\"},{\"topTeam\":{\"id\":52,\"abbrev\":\"WPG\",\"wins\":1,\"seedRank\":2,\"seedAbbrev\":\"D2\"},\"botTeam\":{\"id\":21,\"abbrev\":\"COL\",\"wins\":4,\"seedRank\":3,\"seedAbbrev\":\"D3\"},\"conference\":0,\"seriesLetter\":\"F\"},{\"topTeam\":{\"id\":23,\"abbrev\":\"VAN\",\"wins\":4,\"seedRank\":1,\"seedAbbrev\":\"D1\"},\"botTeam\":{\"id\":18,\"abbrev\":\"NSH\",\"wins\":2,\"seedRank\":4,\"seedAbbrev\":\"WC1\"},\"conference\":0,\"seriesLetter\":\"G\"},{\"topTeam\":{\"id\":22,\"abbrev\":\"EDM\",\"wins\":4,\"seedRank\":2,\"seedAbbrev\":\"D2\"},\"botTeam\":{\"id\":26,\"abbrev\":\"LAK\",\"wins\":1,\"seedRank\":3,\"seedAbbrev\":\"D3\"},\"conference\":0,\"seriesLetter\":\"H\"},{\"topTeam\":{\"id\":13,\"abbrev\":\"FLA\",\"wins\":4,\"seedRank\":1,\"seedAbbrev\":\"D1\"},\"botTeam\":{\"id\":6,\"abbrev\":\"BOS\",\"wins\":2,\"seedRank\":2,\"seedAbbrev\":\"D2\"},\"conference\":1,\"seriesLetter\":\"I\"},{\"topTeam\":{\"id\":3,\"abbrev\":\"NYR\",\"wins\":4,\"seedRank\":1,\"seedAbbrev\":\"D1\"},\"botTeam\":{\"id\":12,\"abbrev\":\"CAR\",\"wins\":2,\"seedRank\":2,\"seedAbbrev\":\"D2\"},\"conference\":1,\"seriesLetter\":\"J\"},{\"topTeam\":{\"id\":25,\"abbrev\":\"DAL\",\"wins\":4,\"seedRank\":1,\"seedAbbrev\":\"D1\"},\"botTeam\":{\"id\":21,\"abbrev\":\"COL\",\"wins\":2,\"seedRank\":3,\"seedAbbrev\":\"D3\"},\"conference\":0,\"seriesLetter\":\"K\"},{\"topTeam\":{\"id\":23,\"abbrev\":\"VAN\",\"wins\":3,\"seedRank\":1,\"seedAbbrev\":\"D1\"},\"botTeam\":{\"id\":22,\"abbrev\":\"EDM\",\"wins\":4,\"seedRank\":2,\"seedAbbrev\":\"D2\"},\"conference\":0,\"seriesLetter\":\"L\"},{\"topTeam\":{\"id\":13,\"abbrev\":\"FLA\",\"wins\":4,\"seedRank\":1,\"seedAbbrev\":\"D1\"},\"botTeam\":{\"id\":3,\"abbrev\":\"NYR\",\"wins\":2,\"seedRank\":1,\"seedAbbrev\":\"D1\"},\"conference\":1,\"seriesLetter\":\"M\"},{\"topTeam\":{\"id\":25,\"abbrev\":\"DAL\",\"wins\":2,\"seedRank\":1,\"seedAbbrev\":\"D1\"},\"botTeam\":{\"id\":22,\"abbrev\":\"EDM\",\"wins\":4,\"seedRank\":2,\"seedAbbrev\":\"D2\"},\"conference\":0,\"seriesLetter\":\"N\"},{\"topTeam\":{\"id\":22,\"abbrev\":\"EDM\",\"wins\":3,\"seedRank\":2,\"seedAbbrev\":\"D2\"},\"botTeam\":{\"id\":13,\"abbrev\":\"FLA\",\"wins\":4,\"seedRank\":1,\"seedAbbrev\":\"D1\"},\"conference\":2,\"seriesLetter\":\"O\"}]}";
        return Content(testData, "application/json");

    }
}