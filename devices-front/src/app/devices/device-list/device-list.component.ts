import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { merge, of } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/internal/operators/map';
import { IDevice } from 'src/app/core/models/device.model';
import { DevicesService } from 'src/app/core/services/devices.service';


@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrls: ['./device-list.component.scss']
})
export class DeviceList implements OnInit{
  title = 'devices';
  myControl = new FormControl();
  filteredDevices: Observable<IDevice[]> = of([]);
  devices: IDevice[] | undefined;

  constructor(private devicesService: DevicesService, private router: Router) { }

  ngOnInit() {
    this.devicesService.getDevices().subscribe(response => {
      this.devices = response;
      this._resetFilteredDevices();
    });
  }

  private _filter(value: string): IDevice[] {
    const filterValue = this._normalizeValue(value);
    return this.devices!.filter(device => this._normalizeValue(device.name).includes(filterValue));
  }

  private _normalizeValue(value: string): string {
    if (value) {
      return value.toLowerCase().replace(/\s/g, '');
    }
    return '';
  }

  clearSearch() {
    this.myControl.reset();
    this._resetFilteredDevices();
  }

  private _resetFilteredDevices() {
    this.filteredDevices = merge(
      this.myControl.valueChanges.pipe(map(value => this._filter(value))),
      of(this.devices!));
  }

  redirectToDeailsPage(device: IDevice) {
    this.router.navigate(['/details'], { state: { data: { device } } });
  }

  public trackItem (index: number, item: IDevice) {
    return item.id;
  }
}
