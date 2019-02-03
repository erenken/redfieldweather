export interface ITemperatureHistory {
    timeOfUpdate: Date;
    degrees: number;
    dewpoint?: number;
    heatIndes?: number;
    windChill?: number;
}
