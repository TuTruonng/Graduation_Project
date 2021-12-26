import ISelectOption from "src/interfaces/ISelectOption";

export const stateApprove: ISelectOption[] = [
    { id: 1, label: 'Approve', value: 'True' },
    { id: 2, label: 'Not Approve', value: 'False' },
];

export const acceptOrder: ISelectOption[] = [
    { id: 1, label: 'Accept', value: 'True' },
    { id: 2, label: 'Not Accept', value: 'False' },
];

export const UserOptions: ISelectOption[] = [
    { id: 1, label: 'Admin', value: 'ADMIN' },
    { id: 2, label: 'Staff', value: 'STAFF' },
];

export const AssignToOptions: ISelectOption[] = [
    {id: 1, label: 'tt22' , value: 'tt22' },
    {id: 2, label: 'staff', value: 'staff' },
    {id: 3, label: 'Tu', value: 'Tu'  }
];