export interface Comment {
  communityId: number;
  id: number;
  authorName?: string;
  authorId: string;
  votesUp: number;
  votesDown: number;
  content: number;
  createdAt: Date;
  editedAt?: Date;
}
