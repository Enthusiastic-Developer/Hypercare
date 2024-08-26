import { Component, OnInit } from '@angular/core'
import { CareOpsService } from 'src/app/shared/services/CareOps.service'

@Component({
  selector: 'app-master-home',
  templateUrl: './master-home.component.html',
  styleUrl: './master-home.component.css'
})
export class MasterHomeComponent implements OnInit {
  testdata: any;
  constructor(private careopsservice: CareOpsService) { }
  ngOnInit(): void {
    this.getAllOpsdata()
  }

  getAllOpsdata() {
    this.careopsservice.GetAllCareOps().subscribe((data) => {
      this.testdata = data;
    })
  }

  newOpsData(){
    
  }
}


