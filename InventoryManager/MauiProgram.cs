﻿using Microsoft.Extensions.Logging;
//using InventoryManager.Data;
using InventoryManager.Services;

namespace InventoryManager;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		//builder.Services.AddSingleton<DatabaseContext>();
		builder.Services.AddSingleton<LocationService>();
		builder.Services.AddSingleton<CategoryService>();
		builder.Services.AddSingleton<ItemService>();

        return builder.Build();
	}
}
