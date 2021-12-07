import { PaginationParams } from "./pagination.params";

export interface CommunityParams extends PaginationParams {
  member: string;
}
