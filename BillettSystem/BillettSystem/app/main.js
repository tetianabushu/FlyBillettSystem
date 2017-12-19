"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_dynamic_1 = require("@angular/platform-browser-dynamic");
var app_module_1 = require("./app.module");
var platform = platform_browser_dynamic_1.platformBrowserDynamic();
platform.bootstrapModule(app_module_1.AppModule).catch(function (err) { return console.error("Help module not found"); });
//platform.bootstrapModule(AdminsideModule).catch(err => console.error("Admin module not found")); 
//# sourceMappingURL=main.js.map