import { Injectable } from '@angular/core';
import { ITemperatureHistory } from './ITemperatureHistory';
import { HttpClient } from '@angular/common/http';
import { log } from 'util';

@Injectable({
    providedIn: 'root'
})
export class WeatherService {
    private baseUrl = 'http://www.redfieldweather.com/api/weatherFlash/';
    constructor(private http: HttpClient) {}

    mockTemp: ITemperatureHistory[] = [
        { timeOfUpdate: new Date(), degrees: 50 }
    ];

    getTemperatureHistory(): ITemperatureHistory[] {
        const url = this.baseUrl + 'history/last/1';
        const tempHistory: ITemperatureHistory[] = [];
        const historyCall = this.http.get<any[]>(url).toPromise();

        historyCall.then(data => {
            log(data.toString());
        }
        );

        return tempHistory;
    }
}
