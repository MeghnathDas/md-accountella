import { KeyValue } from '@angular/common';

export interface MasterEntityInfoModel {
    caption: string;
    visibleColumns: KeyValue<string, string>[];
}
