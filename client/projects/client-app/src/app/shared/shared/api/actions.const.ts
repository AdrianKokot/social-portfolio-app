import { environment } from "../../../../environments/environment";

export interface APIActions {
  community: {
    root: string;
    get: (id: number) => string;
    join: (id: number) => string;
    leave: (id: number) => string;
  },
  discussion: {
    root: string;
    get: (id: number) => string;
  }
}

export const apiActions: APIActions = {
  community: {
    root: environment.backendUrl + 'communities',
    get(id: number) {
      return this.root + '/' + id;
    },
    join(id: number) {
      return this.get(id) + '/join';
    },
    leave(id: number) {
      return this.get(id) + '/leave';
    }
  },
  discussion: {
    root: environment.backendUrl + 'discussions',
    get(id: number) {
      return this.root + '/' + id;
    },
  }
}
