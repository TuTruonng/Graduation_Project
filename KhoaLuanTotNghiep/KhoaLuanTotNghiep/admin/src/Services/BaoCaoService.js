import httpClient from '../Helpers/httpHelper'

class BaoCaoService{
    pathSer="Report"
    
    getList(){
        return httpClient.get(this.pathSer);
    }

    delete(id) {
        return httpClient.delete(this.pathSer + "/" + id);  
      }
}
export default new BaoCaoService();