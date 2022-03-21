import { map, Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IDevice } from '../models/device.model';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class DevicesService {

    constructor(private httpClient: HttpClient) { }

    getDevices(): Observable<IDevice[]> {
        // To test with back-end data
        //return this.httpClient.get<IDevice[]>(environment.url + `devices`);

        // To test with fake data
        return this.httpClient.get<IDevice[]>('assets/fake-backend/fake-devices.json');
    }

    getDeviceById(id: any): Observable<IDevice> {
        // To test with back-end data
        //return this.httpClient.get<IDevice>(environment.url + `devices/${id}`);

        // To test with fake data
        return this.httpClient.get<IDevice[]>('assets/fake-backend/fake-devices.json').pipe(map(data => data.find(dev => dev.id == id)!));
    }
}