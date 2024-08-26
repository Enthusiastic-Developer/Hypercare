import { environment as defaultEnvironment } from './environment';

export const environmentLoader = new Promise<any>((resolve, reject) => {

  var xmlhttp = new XMLHttpRequest(),
    method = 'GET',
    url = './assets/environment/environment.json?v=' + (new Date()).getTime();;

  xmlhttp.open(method, url, true);

  xmlhttp.onload = function () {
    if (xmlhttp.status === 200) {
      resolve(JSON.parse(xmlhttp.responseText));
      var event = document.createEvent('Event');
      event.initEvent('environmentsetupdone', true, true);
      document.dispatchEvent(event);
    } else {
      resolve(defaultEnvironment);
    }
  };

  xmlhttp.send();
});