using _14_ShocrtCircuitASPNET8;

var builder = WebApplication.CreateSlimBuilder(args);
var app = builder.Build();

app.UseRequestLogger();
app.UseStaticFiles();

// SHORT CIRCUIT IS NEW WAY TO
// so if we will have multiple middlewares checking auth, logging or validation will not fire when we use ShortCircuit();


//Works only in minimal api 
//Controller can't do that ShortCircuit()
app.MapGet("_health", () => Results.Ok()).ShortCircuit(); // middleware will not fire
app.MapGet("_test", () => Results.Ok()); // not shortcircuit so it will fire
app.MapShortCircuit(200,
    "htmlpage.html");
app.MapShortCircuit(404,
    "robot.txt", "favicon.ico", "404.html", "sitemap.xml");
app.Run();

