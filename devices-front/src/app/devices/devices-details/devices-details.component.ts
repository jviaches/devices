import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IDevice } from 'src/app/core/models/device.model';
import { DevicesService } from 'src/app/core/services/devices.service';

@Component({
  selector: 'app-devices-details',
  templateUrl: './devices-details.component.html',
  styleUrls: ['./devices-details.component.scss']
})
export class DeviceDetails implements OnInit {
  device: IDevice | undefined;
  relatedDevices: IDevice[] = [];

  constructor(private router: Router, private devicesService: DevicesService,) {
  }

  ngOnInit() {
    this.device = history?.state?.data?.device;
    if (this.device?.relatedDevices) {
      
      this.device.relatedDevices.forEach(devId => {
        this.devicesService.getDeviceById(devId).subscribe(data => {
          this.relatedDevices.push(data);
        });
      });
    }
  }

  redirectToDeailsPage(device: IDevice) {
    this.router.navigate(['/details'], { state: { data: { device } } });
  }

  public trackItem(index: number, item: IDevice) {
    return item.id;
  }
}
