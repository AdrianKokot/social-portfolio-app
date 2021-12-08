export interface Discussion {
  communityId: number;
  id: number;
  title: string;
  authorName?: string;
  authorId: string;
  votesUp: number;
  votesDown: number;
  content: number;
  createdAt: Date;
  editedAt?: Date;
  commentsCount: number;
}
