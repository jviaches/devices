
import { NgModule } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { DeviceList } from './device-list/device-list.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DeviceDetails } from './devices-details/devices-details.component';
import {MatGridListModule} from '@angular/material/grid-list';

@NgModule({
  declarations: [
    DeviceList,
    DeviceDetails
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatAutocompleteModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    FormsModule,
    MatGridListModule
  ],
  exports:[
  ],
  providers: [],
  bootstrap: [DeviceList]
})
export class DevicesModule { }