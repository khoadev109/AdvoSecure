export interface Note {
  id: string;
  title: string;
  body: string;
  timestamp?: Date;
}

export const defaultNote: Note = {
  id: '',
  title: '',
  body: '',
};
