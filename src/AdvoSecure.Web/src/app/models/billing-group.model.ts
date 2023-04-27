export interface BillingGroup {
  id: number;
  title: string;
  lastRun?: string;
  nextRun?: string;
  amount: number;
  billToContactId: number;
}
