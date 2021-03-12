import { JobPortalTemplatePage } from './app.po';

describe('JobPortal App', function() {
  let page: JobPortalTemplatePage;

  beforeEach(() => {
    page = new JobPortalTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
