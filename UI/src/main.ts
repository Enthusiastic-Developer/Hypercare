import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic'

import { AppModule } from './app/app.module'
import { environment } from './environments/environment';
import { environmentLoader as environmentLoaderPromise } from './environments/environmentLoader';


if (environment.production) {
  enableProdMode();
}

environmentLoaderPromise.then(env => {

  if (environment.production) {
    environment.URLS = env.URLS;
  }
  platformBrowserDynamic().bootstrapModule(AppModule)
    .catch(err => { console.error(err) });
});
