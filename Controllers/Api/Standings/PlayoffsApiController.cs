using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using NHL_Dashboards.Models;
using NHL_Dashboards.Services;

namespace NHL_Dashboards.Controllers.Api.Standings;

[ApiController]
[Route("[controller]")]
public class PlayoffsApiController(ILogger<PlayoffsApiController> logger, NhlApi nhlApi) : ControllerBase
{
    private readonly ILogger<PlayoffsApiController> _logger = logger;
    private readonly NhlApi _nhlApi = nhlApi;

    [HttpGet]
    [OpenApiTag("Standings")]
    [ProducesResponseType<PlayoffsStandingsApiModel>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] string year = "")
    {
        NhlPlayoffBracketModel Bracket;

        try
        {
            Bracket = await _nhlApi.GetPlayoffBracketAsync(year);
        }
        catch (Exception ex)
        {
            return Problem
            (
                title: "Getting Standings data from NHL",
                detail: ex.Message,
                statusCode: 500
            );
        }

        var Output = new PlayoffsStandingsApiModel();

        var AllSeries = Bracket.Series;

        // goes through each series from the data received
        foreach (var series in AllSeries)
        {
            var SeriesResult = new PlayoffsStandingsApiModel.SeriesData();
            SeriesResult.SeriesLetter = series.SeriesLetter;

            // all of the series that are in the Eastern Conf
            if ("ABCDJIM".Contains(series.SeriesLetter))
                SeriesResult.Conference = "Eastern";
            // all of the series that are in the Western Conf
            else if ("EFGHKLN".Contains(series.SeriesLetter))
                SeriesResult.Conference = "Western";
            // the only other option is for it to be the final
            else
                SeriesResult.Conference = "StanleyCupFinal";

            if (series.TopSeedTeam == null || series.BottomSeedTeam == null)
            {
                Output.Series.Add(SeriesResult);
                continue;
            }

            // nothing special is needed for the first round, the data is already in the format we want
            if (series.PlayoffRound == 1)
            {
                SeriesResult.TopTeam = new(
                    series.TopSeedTeam,
                    series.TopSeedWins,
                    series.TopSeedRank,
                    series.TopSeedRankAbbrev
                );
                SeriesResult.BotTeam = new(
                    series.BottomSeedTeam,
                    series.BottomSeedWins,
                    series.BottomSeedRank,
                    series.BottomSeedRankAbbrev
                );
            }
            /* For the all the rounds after the first the data only tells us the seeds ranks but that
                * doesn't help for positioning of the playoff bracket. To find the correct positioning it
                * looks at the series that is 1) from the previous round, 2) 1 of the 2 series that led into
                * this one, and 3) was higher up in the graphic. It then puts the teams that was in that
                * previous series on top.
                */
            else
            {
                /* The series that is:
                    * 1) from the previous round
                    * 2) 1 of the 2 series that led into this one
                    * 3) was higher up in the graphic
                    */
                string previousRoundTopSeriesLetter = "";
                if (series.SeriesLetter == "I")
                    previousRoundTopSeriesLetter = "A";
                else if (series.SeriesLetter == "J")
                    previousRoundTopSeriesLetter = "C";
                else if (series.SeriesLetter == "K")
                    previousRoundTopSeriesLetter = "E";
                else if (series.SeriesLetter == "L")
                    previousRoundTopSeriesLetter = "G";
                else if (series.SeriesLetter == "M")
                    previousRoundTopSeriesLetter = "I";
                else if (series.SeriesLetter == "N")
                    previousRoundTopSeriesLetter = "K";
                else if (series.SeriesLetter == "O")
                    previousRoundTopSeriesLetter = "N";

                // grabs that series data
                NhlPlayoffBracketModel.SeriesData previousRoundTopSeries = AllSeries.FirstOrDefault(
                    x => x.SeriesLetter == previousRoundTopSeriesLetter
                )!;

                // puts the ids from that series into a list for easy compare later
                List<int> previousRoundTopSeriesTeamIds =
                [
                    previousRoundTopSeries.TopSeedTeam!.Id,
                    previousRoundTopSeries.BottomSeedTeam!.Id,
                ];

                // sets the data accordingly based on who was in that previous round
                if (previousRoundTopSeriesTeamIds.Contains(series.TopSeedTeam.Id))
                {
                    SeriesResult.TopTeam = new PlayoffsStandingsApiModel.SeriesData.TeamData(
                        series.TopSeedTeam,
                        series.TopSeedWins,
                        series.TopSeedRank,
                        series.TopSeedRankAbbrev
                        );
                    SeriesResult.BotTeam = new PlayoffsStandingsApiModel.SeriesData.TeamData(
                        series.BottomSeedTeam,
                        series.BottomSeedWins,
                        series.BottomSeedRank,
                        series.BottomSeedRankAbbrev
                    );
                }
                else
                {
                    SeriesResult.TopTeam = new PlayoffsStandingsApiModel.SeriesData.TeamData(
                        series.BottomSeedTeam,
                        series.BottomSeedWins,
                        series.BottomSeedRank,
                        series.BottomSeedRankAbbrev
                    );
                    SeriesResult.BotTeam = new PlayoffsStandingsApiModel.SeriesData.TeamData(
                        series.TopSeedTeam,
                        series.TopSeedWins,
                        series.TopSeedRank,
                        series.TopSeedRankAbbrev
                    );
                }
            }

            Output.Series.Add(SeriesResult);
        }

        return Ok(Output);
    }
}