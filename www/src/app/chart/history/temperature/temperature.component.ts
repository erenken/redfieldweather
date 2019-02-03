import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'rw-temperature-history',
  templateUrl: './temperature.component.html',
  styleUrls: ['./temperature.component.css']
})

export class TemperatureHistoryComponent implements OnInit {
    chartTitle = 'Temperature';
    type = 'Line';
    data = [
       ['Firefox', 45.0],
       ['IE', 26.8],
       ['Chrome', 12.8],
       ['Safari', 8.5],
       ['Opera', 6.2],
       ['Others', 0.7]
    ];
    columnNames = ['Time', 'Temperature'];
    options = { legend: { position: 'bottom' } };
    width = 800;
    height = 400;

  constructor() { }

  ngOnInit() {
  }

}
