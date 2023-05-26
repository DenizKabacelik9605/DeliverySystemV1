import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {map} from "rxjs/operators"
@Injectable({
  providedIn: 'root'
})
export class Api2Service {
  

  constructor(private http:HttpClient) { }


  postDelivery(data:any){
    return this.http.post<any>("http://localhost:3000/posts", data)
    .pipe(map((res:any)=>{
      return res;
    } 
    ))  
  }
  getAllDelivery(){
    return this.http.get<any>("https://localhost:7026/api/Delivery2")
    .pipe(map((res:any)=>{

        console.log("res", res);
      return res;
    } 
    ))  
  }


  updateDelivery(data:any, id:number){
    return this.http.put<any>("http://localhost:3000/posts/" +id,data)
    .pipe(map((res:any)=>{
      return res;
    } 
    ))  
  }

  
  deleteDelivery( id:number){
    return this.http.delete<any>("http://localhost:3000/posts/" +id)
    .pipe(map((res:any)=>{
      return res;
    } 
    ))  
  }
}
