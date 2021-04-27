import { Component } from '@angular/core';
import { TemperatureService } from 'src/app/core/TemperatureService';

@Component({
  selector: 'app-temp-converter',
  templateUrl: 'temp-converter.component.html',
  styleUrls: ['temp-converter.component.css']
})
export class TempConverterComponent {

  public units: string[] = ['Celsius', 'Farenheit', 'Kelvin']
  
  public selectedFromUnit: string;
  public selectedToUnit: string;
  public valueToConvert: number;
  public result: number;

  constructor(private tempService: TemperatureService) {
    this.selectedFromUnit = '';
    this.selectedToUnit = '';
    this.valueToConvert = 0;
  } 

  public async convertTemperatureValue() {
    this.result = await this.tempService.ConvertTemperatureValue(this.selectedFromUnit, this.selectedToUnit, this.valueToConvert);
    console.log(this.result);
    // console.log(this.selectedFromUnit);
    // console.log(this.selectedToUnit);
    // console.log(this.valueToConvert);
  }

  public assignToUnit(unit: string): void {
    this.selectedToUnit = unit;
  }
  
}
