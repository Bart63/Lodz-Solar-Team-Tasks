export interface CarSummary{
    'general': {
        'timestamp': string,
        'speed': number,
        'mileage': number,
        'driveMode': string
    },
    'battery': {
        'stateOfCharge': number
        'temperature': number   
        'errors': {
            'overheat': boolean
            'noSignal': boolean
            'other': boolean
        }
    },
    'tires': {
        'pressure': Array<number>
    }
}