export interface IDevice {
    id: string;
    name: string;
    type: DeviceType;
    status: DeviceStatus;
    relatedDevices: string[];    
}

export enum DeviceStatus {
    Offline,
    Online,
    Available,
    Unknown
}

export enum DeviceType {
    Unknown = 'Unknown',
    IPhoneMobile = 'IPhone Mobile',
    IPhoneTablet = 'IPhone Tablet',
    Desktop = 'Desktop',
}
