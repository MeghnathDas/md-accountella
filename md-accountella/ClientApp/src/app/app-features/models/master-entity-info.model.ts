import { KeyValue } from '@angular/common';

export interface MasterEntityInfoModel {
    id: number;
    caption: string;
    visibleColumns: KeyValue<string, string>[];
}
