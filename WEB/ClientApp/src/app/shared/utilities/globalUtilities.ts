export class GlobalUtilities {
  getApiUrl(api: string) : string {
    return window.location.origin.replace(":44306", ":44327") + "/" + api;
  }
}
