import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-con',
  templateUrl: './show-con.component.html',
  styleUrls: ['./show-con.component.css']
})
export class ShowConComponent implements OnInit {

  constructor(private service:SharedService) { }

  ContractorList:any=[];

  ModalTitle:string;
  ActivateAddEditConComp:boolean=false;
  con:any;

  ngOnInit(): void {
    this.refreshConList();
  }

addClick()
{
  this.con={
    id:0,
    name:"",
    surname:"",
    city:"",
    departmentName:"",
    dateOfBirth:""
  }
  this.ModalTitle="Dodaj kontrahenta";
  this.ActivateAddEditConComp=true;
}

editClick(item)
{
  this.con=item;
  this.ModalTitle="Edytuj kontrahenta";
  this.ActivateAddEditConComp=true;
}

deleteClick(item)
{
  if(confirm('Jestes pewny?'))
  {
    this.service.deleteContractor(item.id).subscribe(data=>{
      alert(data.toString());
      this.refreshConList();
    })
  }
}

closeClick()
{
  this.ActivateAddEditConComp=false;
  this.refreshConList();
}

  refreshConList()
  {
    this.service.getConList().subscribe(data=>{this.ContractorList=data;})
  }

}
