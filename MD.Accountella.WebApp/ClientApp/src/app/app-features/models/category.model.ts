export interface Category {
    id: string;
    name: string;
    isReadOnly: boolean;
    sequenceNo: number;
    subCategories: Category[];
    _ParentId: string;
    parent: Category;
}
