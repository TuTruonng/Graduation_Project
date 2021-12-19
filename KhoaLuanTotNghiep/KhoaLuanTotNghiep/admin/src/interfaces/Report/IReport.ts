export default interface IReport {
    reportID?: string;
    realEstateID: string;
    status: string;
    createTime: Date;
    updateTime: Date;
    ipAddress: string;
    title?: string;
}