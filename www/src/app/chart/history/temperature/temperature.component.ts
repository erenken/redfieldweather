import { Component, OnInit } from '@angular/core';
import { WeatherService } from 'app/service/weather.service';
import { ITemperatureHistory } from 'app/service/ITemperatureHistory';

@Component({
  selector: 'rw-temperature-history',
  templateUrl: './temperature.component.html',
  styleUrls: ['./temperature.component.css']
})

export class TemperatureHistoryComponent implements OnInit {
    loaded = false;
    chartTitle = 'Temperature';
    type = 'Line';
    data: ITemperatureHistory[] = [];
    columnNames = ['Time', 'Temperature'];
    options = { legend: { position: 'bottom' } };
    width = 800;
    height = 400;

  constructor(private weatherService: WeatherService) { }

  ngOnInit() {
      this.getTemperatureHistory();
  }

  getTemperatureHistory() {
      this.data = this.weatherService.getTemperatureHistory();
      this.loaded = true;
  }
}
