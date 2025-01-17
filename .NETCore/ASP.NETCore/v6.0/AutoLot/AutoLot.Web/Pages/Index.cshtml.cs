﻿namespace AutoLot.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IAppLogging<IndexModel> _appLogging;

    [ViewData]
    public string Title => "Home page";

    [TempData]
    public string Message { get; set; }

    [BindProperty]
    public DealerInfo Entity { get; set; }
    public IndexModel(IAppLogging<IndexModel> appLogging)
    {
        _appLogging = appLogging;
    }

    public void OnGet([FromServices]IOptionsMonitor<DealerInfo> dealerOptionsMonitor)
    {
        Entity = dealerOptionsMonitor.CurrentValue;
        _appLogging.LogAppDebug("Entered On Get");
    }
}