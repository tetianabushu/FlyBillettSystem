import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app.module';

const platform = platformBrowserDynamic();

platform.bootstrapModule(AppModule).catch(err => console.error("Help module not found"));
//platform.bootstrapModule(AdminsideModule).catch(err => console.error("Admin module not found"));