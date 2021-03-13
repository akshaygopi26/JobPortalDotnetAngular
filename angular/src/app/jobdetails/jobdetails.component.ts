import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
  JobListDTO,
  JobServiceProxy,
  UpdateJobInputDTO,
  JobListDTOListResultDto
} from '@shared/service-proxies/service-proxies';
import {CreateJobComponent } from './create-job/create-job.component';
import {EditJobComponent  } from './edit-job/edit-job.component';


class PagedJobsRequestDto extends PagedRequestDto {
  companyName: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-jobdetails',
  templateUrl: './jobdetails.component.html',
  styleUrls: ['./jobdetails.component.css']
})
export class JobdetailsComponent extends PagedListingComponentBase<JobListDTO> {
  jobs: JobListDTO[] = [];
  companyName = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _jobService: JobServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.getAllJobs("");
  }

  getAllJobs(companyName: string){
    this._jobService.getAll(companyName)
    .pipe(
     finalize(() => {
       console.log("Error")
       // finishedCallback();
     })
    )
     .subscribe( data => { 
      console.log(data)
      this.jobs=data.items;
 
    });
   }

  createJob(): void {
    this.showCreateOrEditJob();
  }

  editJob(job: UpdateJobInputDTO): void {
    //this.showCreateOrEditJob(job.id);
    this.ShowEditJob(job);
  }

  clearFilters(): void {
    this.companyName = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  protected list(
    request: PagedJobsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.companyName = this.companyName;
    request.isActive = this.isActive;

  
    this._jobService.getAll(request.companyName)
    .pipe(
     finalize(() => {
      // console.log("Error")
        finishedCallback();
     })
    )
     .subscribe( data => { 
      console.log(data)
      this.jobs=data.items;
 
    });
      // .getAll(
      //   request.keyword,
      //   request.isActive,
      //   request.skipCount,
      //   request.maxResultCount
      // )
      // .pipe(
      //   finalize(() => {
      //     finishedCallback();
      //   })
      // )
      // .subscribe((result: UserDtoPagedResultDto) => {
      //   this.users = result.items;
      //   this.showPaging(result, pageNumber);
      // });
  }

  protected delete(job: JobListDTO): void {
    abp.message.confirm(
      this.l('JobDeleteWarningMessage', job.companyName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._jobService.deleteJob(job.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  

  private showCreateOrEditJob(id?: number): void {
    let createOrEditJob: BsModalRef;
    if (!id) {
      createOrEditJob = this._modalService.show(
        CreateJobComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditJob = this._modalService.show(
        EditJobComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditJob.content.onSave.subscribe(() => {
      this.refresh();
    });
  }


  
  private ShowEditJob(job: UpdateJobInputDTO): void {
    let createOrEditJob: BsModalRef;
    if (!job) {
      createOrEditJob = this._modalService.show(
        CreateJobComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditJob = this._modalService.show(
        EditJobComponent,
        {
          class: 'modal-lg',
          initialState: {
            //id: job.id,
            jobDetails : job
          },
        }
      );
    }

    createOrEditJob.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}

