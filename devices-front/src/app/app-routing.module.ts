import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeviceList } from './devices/device-list/device-list.component';
import { DeviceDetails } from './devices/devices-details/devices-details.component';

const routes: Routes = [
  { path: '', component: DeviceList },
  { path: 'details', component: DeviceDetails }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
