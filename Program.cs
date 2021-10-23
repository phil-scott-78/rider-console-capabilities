using Spectre.Console;

// running via Rider results in an encoding of "Codepage - 437". Running via the Terminal of rider via dotnet run results in a codepage of "Unicode (UTF-8)"
// Both .NET Console's "Console Output Encoding" and "Default Encoding" for the Console are set to UTF-8
//
// this setting only adjusts the ability of Spectre.Console to detect the output capabilities, setting it does not improve
// the ability to render emojis or color

// System.Console.OutputEncoding = Encoding.UTF8;

var grid = new Grid()
    .AddColumn(new GridColumn().NoWrap().PadRight(4))
    .AddColumn()
    .AddRow("[b]Enrichers[/]", string.Join(", ", AnsiConsole.Profile.Enrichers))
    .AddRow("[b]Color system[/]", $"{AnsiConsole.Profile.Capabilities.ColorSystem}")
    .AddRow("[b]Unicode?[/]", $"{YesNo(AnsiConsole.Profile.Capabilities.Unicode)}")
    .AddRow("[b]Supports ansi?[/]", $"{YesNo(AnsiConsole.Profile.Capabilities.Ansi)}")
    .AddRow("[b]Supports links?[/]", $"{YesNo(AnsiConsole.Profile.Capabilities.Links)}")
    .AddRow("[b]Legacy console?[/]", $"{YesNo(AnsiConsole.Profile.Capabilities.Legacy)}")
    .AddRow("[b]Interactive?[/]", $"{YesNo(AnsiConsole.Profile.Capabilities.Interactive)}")
    .AddRow("[b]Terminal?[/]", $"{YesNo(AnsiConsole.Profile.Out.IsTerminal)}")
    .AddRow("[b]Buffer width[/]", $"{AnsiConsole.Console.Profile.Width}")
    .AddRow("[b]Buffer height[/]", $"{AnsiConsole.Console.Profile.Height}")
    .AddRow("[b]Encoding[/]", $"{AnsiConsole.Console.Profile.Encoding.EncodingName}")
    .AddRow("[b]Powerline Test[/]", "")
    .AddRow("[b]Emoji Test[/]", ":rocket: :cat:")
    .AddRow(new Markup("[b]Color Test[/]"), new ColorBox(40, 1));

AnsiConsole.Write(
    new Panel(grid)
        .RoundedBorder()
        .Header("Information"));

static string YesNo(bool value) => value ? "Yes" : "No";