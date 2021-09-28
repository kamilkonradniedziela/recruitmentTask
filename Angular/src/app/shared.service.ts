import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl="http://localhost:5000/api";

  constructor(private http:HttpClient) { }

  getDepList():Observable<any[]>
  {
    return this.http.get<any>(this.APIUrl+'/department');
  }

  addDepartment(val:any)
  {
    return this.http.post(this.APIUrl+'/department',val);
  }

  updateDepartment(val:any)
  {
    return this.http.put(this.APIUrl+'/department', val);
  }

  deleteDepartment(val:any)
  {
    return this.http.delete(this.APIUrl+'/department/' + val);
  }



  getConList():Observable<any[]>
  {
    return this.http.get<any>(this.APIUrl+'/contractor');
  }

  addContractor(val:any)
  {
    return this.http.post(this.APIUrl+'/contractor',val);
  }

  updateContractor(val:any)
  {
    return this.http.put(this.APIUrl+'/contractor', val);
  }

  deleteContractor(val:any)
  {
    return this.http.delete(this.APIUrl+'/contractor/' + val);
  }


  getAllDepartmentNames():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+'/contractor/getAllDepartmentNames');
  }
}
