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
  JobListDTOListResultDto,
  JobListDTOPagedResultDto,
  AppliedJobsServiceProxy,
  CreateAppliedJob,
  
} from '@shared/service-proxies/service-proxies';
import {CreateJobComponent } from './create-job/create-job.component';
import {EditJobComponent  } from './edit-job/edit-job.component';
import { PermissionCheckerService } from 'abp-ng2-module';


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
  appliedjob = new CreateAppliedJob();
  advancedFiltersVisible = false;
  isApplicant = false;
  isRecruiter = false;
  hasNoRole = false;

  constructor(
    injector: Injector,
    private _jobService: JobServiceProxy,
    private _appliedJobService  :AppliedJobsServiceProxy,
    private _modalService: BsModalService,
    private _permissionChecker : PermissionCheckerService
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.getAllJobs("",0,10);
    this.isApplicant = this._permissionChecker.isGranted("Pages.Applicants");
    this.isRecruiter = this._permissionChecker.isGranted("Pages.Recruiters");
    this.hasNoRole = !this.isApplicant && !this.isRecruiter;
  }

  getAllJobs(companyName: string,skipCount: number,maxResultCount: number){
    this._jobService.getNotAppliedJobs(companyName,null,skipCount,maxResultCount)
    .pipe(
     finalize(() => {
       console.log("Error")
       // finishedCallback();
     })
    )
     .subscribe( data => { 
      console.log(data)
      this.jobs=data.items;
      this.totalItems=data.totalCount;
    });
   }

  createJob(): void {
    this.showCreateOrEditJob();
  }

  editJob(job: UpdateJobInputDTO): void {
    //this.showCreateOrEditJob(job.id);
    this.ShowEditJob(job);
  }

  applyJob(job: JobListDTO): void {
    //this.showCreateOrEditJob(job.id);
    this.ApplyForJob(job);
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

  
    // this._jobService.getAll(request.companyName)
    // .pipe(
    //  finalize(() => {
    //   // console.log("Error")
    //     finishedCallback();
    //  })
    // )
    //  .subscribe( data => { 
    //   console.log(data)
    //   this.jobs=data.items;
 
    // });

      this._jobService
      .getNotAppliedJobs(
        request.companyName,
        null,
        //request.isActive,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: JobListDTOPagedResultDto) => {
        this.jobs = result.items;
        this.showPaging(result, pageNumber);
      });
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


  private ApplyForJob(job: JobListDTO): void {

    console.log("Job ID : "+job.id);
    this.appliedjob.jobId=job.id;
    // this._appliedJobService
    //   .createApplyJob(this.appliedjob)
    //   .pipe(
    //     finalize(() => {
    //      /// this.saving = false;
    //     })
    //   )
    //   .subscribe(() => {
    //     this.notify.info(this.l('SavedSuccessfully'));
    //    // this.bsModalRef.hide();
    //   //  this.onSave.emit();
    //   });

 


      abp.message.confirm(
        this.l('Do you want to apply for this Job', job.companyName),
        undefined,
        (result: boolean) => {
          if (result) {
            this._appliedJobService.createApplyJob(this.appliedjob)
            .pipe(
              finalize(() => {
               /// this.saving = false;
              }))
            .subscribe(() => {
              abp.notify.success(this.l('Successfully Applied'));
              this.refresh();
            });
          }
        }
      );
  }
    
}




