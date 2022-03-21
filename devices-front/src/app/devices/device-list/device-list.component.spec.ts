import { ComponentFixture, fakeAsync, TestBed, waitForAsync } from "@angular/core/testing";
import { AppModule } from "src/app/app.module";
import { DevicesService } from "src/app/core/services/devices.service";
import { DeviceList } from "./device-list.component";

let component: DeviceList;
let fixture: ComponentFixture<DeviceList>;

describe('Device List component', () => {
  beforeEach(waitForAsync(() => {
    TestBed
      .configureTestingModule({
        declarations: [DeviceList],
        imports: [
          AppModule,
        ],
        providers: [DevicesService]
      })
      .compileComponents();
  }));

  it('should render input search', fakeAsync(() => {
    let searchInput: HTMLElement;

    fixture = TestBed.createComponent(DeviceList);
    component = fixture.componentInstance;
    searchInput = fixture.nativeElement.querySelector('input');
    expect(searchInput).toBeTruthy();
  }));

  it('should render button search', fakeAsync(() => {
    let searchButton: HTMLElement;
    
    fixture = TestBed.createComponent(DeviceList);
    component = fixture.componentInstance;
    searchButton = fixture.nativeElement.querySelector('a');
    expect(searchButton).toBeTruthy();
  }));
});