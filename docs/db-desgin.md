## ER Diagram

```mermaid
erDiagram
	AbpUser ||--o{ContactPersion : persion-intive

	ContactPersion {
		Guid Id
		string Email
		string FirstName
		string LastName
		string Phone
		string Address
		string Job
		Datetime Birthday
		bool BestFriend
		string Note
		int Relationship
	}

```

## Tables

| # | Table                         | Note | 
| - | -----                         | ---- |
| 1 | AbpUsers                      | A prefined table by ABP.io |
| 2 | ContactPersion				| Persion add by User |