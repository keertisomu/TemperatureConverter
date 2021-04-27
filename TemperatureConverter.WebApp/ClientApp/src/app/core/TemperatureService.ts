import { APP_BASE_HREF } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';


@Injectable()
export class TemperatureService {

    public root = '';

    constructor(
        @Inject(APP_BASE_HREF)
        private href: string,
        private http: HttpClient) {
      }

  // call temperature service api to convert values.
  public async ConvertTemperatureValue(
    fromUnit: string,
    toUnit: string,
    valueToConvert: number): Promise<number> {
    return new Promise<number>((resolve, reject) => {
      this.http.get<number>(         
            `${this.root}/api/v1/temperatureconverter/${fromUnit}/units/${toUnit}/convert/${valueToConvert}`,
          ).subscribe(
          (result) => {
            resolve(result);
          },
          (error) => {
            reject(error);
          },
        );
    });
  }
}