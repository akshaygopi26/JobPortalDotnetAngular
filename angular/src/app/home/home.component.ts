import { Component, Injector, ChangeDetectionStrategy } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
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
import { PermissionCheckerService } from 'abp-ng2-module';


class PagedJobsRequestDto extends PagedRequestDto {
  companyName: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './home.component.html',
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent extends AppComponentBase {

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
    this.isApplicant = this._permissionChecker.isGranted("Pages.Applicants");
    this.isRecruiter = this._permissionChecker.isGranted("Pages.Recruiters");
    this.hasNoRole = !this.isApplicant && !this.isRecruiter;
  }

  Recruiter(job: JobListDTO): void {
    
  }

  Applicant(job: JobListDTO): void {
    
  }

    
  }
    






