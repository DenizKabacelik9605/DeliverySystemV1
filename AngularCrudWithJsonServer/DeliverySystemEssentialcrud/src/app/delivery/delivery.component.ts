import { Component } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import { DeliveryModel } from './delivery.model';
import {ApiService} from '../api.service'
import {Api2Service} from '../api2.service'

@Component({
  selector: 'app-delivery',
  templateUrl: './delivery.component.html',
  styleUrls: ['./delivery.component.scss']
})
export class DeliveryComponent {
    public get formbuilder(): FormBuilder {
      return this._formbuilder;
    }
    public set formbuilder(value: FormBuilder) {
      this._formbuilder = value;
    }

    formValue!:FormGroup;
    deliveryModelObj:DeliveryModel=new DeliveryModel();
    deliveryData!:any;
    showAdd!:boolean;
    showUpdate!:boolean;
    constructor(private _formbuilder: FormBuilder,
      private api:ApiService,
      private api2:Api2Service
      ){}

    ngOnInit():void{

          this.formValue=this.formbuilder.group({

            customerFullName:[''],
            customerAddress:[''],
            vehicleId:[''],
            deliverySelectedOption:[''],
            deliverySelectedDate:['']
          })
          this.getAllDelivery();
    }
    
      clickAddDelivery(){

        this.formValue.reset();
        this.showAdd=true;
        this.showUpdate=false;
      }
    postDeliveryDetails(){
      this.deliveryModelObj.customerFullName=this.formValue.value.customerFullName;
      this.deliveryModelObj.customerAddress=this.formValue.value.customerAddress;
      this.deliveryModelObj.vehicleId=this.formValue.value.vehicleId;
      this.deliveryModelObj.deliverySelectedOption=this.formValue.value.deliverySelectedOption;
      this.deliveryModelObj.deliverySelectedDate=this.formValue.value.deliverySelectedDate;
      
      this.api.postDelivery(this.deliveryModelObj)
      .subscribe(res=>{
        console.log(this.deliveryModelObj);
        console.log(res);
        alert("Delivery Added Succesfully");
        let ref=document.getElementById("cancel");
        ref?.click();
        this.formValue.reset();
      },
      err=>{
        alert("Something Went Wrong");
      }
      )
    }

    getAllDelivery(){
      this.api.getAllDelivery()
      .subscribe(res=>{
          this.deliveryData=res;

      })
    }


    deleteDelivery(row:any){
      this.api.deleteDelivery(row.id)
      .subscribe(res=>{
        alert("Delivery Deleted");
        this.getAllDelivery();
      });
    }

    onEdit(row:any){
      this.showAdd=false;
      this.showUpdate=true;
      this.deliveryModelObj.id=row.id;
      this.formValue.controls["customerFullName"].setValue(row.customerFullName);
      this.formValue.controls["customerAddress"].setValue(row.customerAddress);
      this.formValue.controls["vehicleId"].setValue(row.vehicleId);
      this.formValue.controls["deliverySelectedOption"].setValue(row.deliverySelectedOption);
      this.formValue.controls["deliverySelectedDate"].setValue(row.deliverySelectedDate);
   
   
    }


    updateDeliveryDetails(){

      this.deliveryModelObj.customerFullName=this.formValue.value.customerFullName;
      this.deliveryModelObj.customerAddress=this.formValue.value.customerAddress;
      this.deliveryModelObj.vehicleId=this.formValue.value.vehicleId;
      this.deliveryModelObj.deliverySelectedOption=this.formValue.value.deliverySelectedOption;
      this.deliveryModelObj.deliverySelectedDate=this.formValue.value.deliverySelectedDate;
      this.api.updateDelivery(this.deliveryModelObj, this.deliveryModelObj.id)
      .subscribe(res=>{
        alert("Updated Successfully");
        let ref=document.getElementById("cancel");
        ref?.click();
        this.formValue.reset();
        this.getAllDelivery();
      })
    }
}


















