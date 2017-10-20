CREATE DATABASE AcmeDraw
GO
USE AcmeDraw
GO
CREATE TABLE [dbo].[Serials] (
	[Serial] [nvarchar](36) NOT NULL 
PRIMARY KEY ([Serial]))
GO
CREATE TABLE [dbo].[SerialRegistration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[Serial] [nvarchar](36) NOT NULL,
	[Registered] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_SerialRegistration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SerialRegistration]  WITH CHECK ADD  CONSTRAINT [FK_SerialRegistration_Serials] FOREIGN KEY([Serial])
REFERENCES [dbo].[Serials] ([Serial])
GO

ALTER TABLE [dbo].[SerialRegistration] CHECK CONSTRAINT [FK_SerialRegistration_Serials]
GO

INSERT INTO [dbo].[Serials] ([Serial]) VALUES 
('08780a9b-08c7-46bd-b198-3e08e25c8f3b'), 
('09de2c4f-a7d4-4c09-b0f0-33edcb8e8399'), 
('0bae7217-3ab8-42e8-8a40-be83e6d4693f'), 
('0ee785a3-a689-4a03-9568-c1ca481a172e'), 
('0eeeda7b-681c-4019-9963-a6aec86c08b9'), 
('0f4b2adf-f0a1-4d53-a646-eb66820e3a94'), 
('135e6dc0-6c4c-4b84-ba3e-734d8e3f22bf'), 
('17a376b0-a647-4403-b0e5-f824e5522756'), 
('19c5ab3c-2f8d-4f02-abf1-62b1c3a22b38'), 
('1a4f8951-e8c5-4aa6-9dd4-144612e77b8d'), 
('1c110d4d-2b58-4ad6-bc3b-7ff24760e2bb'), 
('24412c78-6ad1-4154-8bc7-908be1a7be0c'), 
('2f155357-098e-4121-a8c1-005d8d3a710c'), 
('30036163-fb7b-45ba-b7ed-af32e1cfd615'), 
('303b4f4a-4478-402a-a98b-47d9cc5a0b5b'), 
('30f73e35-7288-483f-908f-8f2704370b61'), 
('31f8e869-d037-4300-8343-6d7df7c5f4a4'), 
('337f31a5-6a66-4457-80a9-94928f363248'), 
('3644fab3-0e69-43f7-9e07-313a8d97c04a'), 
('364c5cdd-baea-48c3-b9f2-a05b4712ee7e'), 
('36935c97-78df-43c7-a79f-68fd82796111'), 
('3ad8ce4c-16c9-44a3-b6de-da30c88118c2'), 
('3dbe78c8-f458-4b17-b786-7a52930944ed'), 
('42c470c7-a9a8-42f3-818f-629be7d13207'), 
('4565eecf-e38e-4235-ac10-f24d7488599a'), 
('45e358ec-b112-4b1e-bacf-13d16146c7a8'), 
('46944952-2f88-4e04-ac85-974ee26f77bb'), 
('46cdaab3-f4a1-4c6e-9e91-59129b4c4f43'), 
('476251be-2205-4614-b16a-d804cceb4427'), 
('4daf56b5-5c63-4592-a8ec-9c09f05671fd'), 
('50df7a39-d3a5-4cd1-b81b-e5ca591e2d08'), 
('54896f1e-53bb-4247-a6b4-6127dbef4d9d'), 
('5886f387-ae1c-4de6-b21f-3d2e46b1bfb5'), 
('5959e9df-8b0f-4fd8-bd6f-0de4a8663797'), 
('59daed62-ea4f-4793-833e-00a67254126b'), 
('5a734411-8d28-403a-9a6a-ee2cd063a0a6'), 
('5c8be502-a75b-49c8-bebb-2a2fda310cd0'), 
('5fad0978-e43c-4d2b-9480-fe41be9de3dc'), 
('601e815d-e261-4c5c-9cc8-20037cd7538f'), 
('61afbcb5-81ac-4aab-af6f-4ee8f021297f'), 
('645e6379-7949-4ed2-b2f1-f386e44b1656'), 
('65cda9f7-e8e1-4b15-a564-16261c9da716'), 
('686dbb0f-7e86-4b14-ad84-4477ff0203d1'), 
('687261b4-0d51-42b9-b4ed-165bc7c5e577'), 
('69d34fc1-0af2-4bd1-80f3-b14722c5a055'), 
('78b6fc81-f4eb-4246-9a16-e5bdadf77426'), 
('7f64f59d-8ad8-4469-8bc5-cb2ee605b007'), 
('81a0bc27-5ae7-44a1-b5d1-d26471812303'), 
('83200dc1-2586-4f4b-a316-07471b15f3ad'), 
('83c084e0-7a36-48d5-84aa-b1e9b9c473b7'), 
('84556c62-10ae-439a-a8d3-65bf0afca80c'), 
('8917549c-1ff6-4c71-9da6-28d4d93e7209'), 
('91d34fa6-6715-4d59-87cf-8b728e649f0c'), 
('926f7279-d899-471b-a6e7-18e24ce3fd04'), 
('930dca5b-3bfd-41fd-841d-4181f154a6e3'), 
('9769769d-b417-4243-8ace-324f7f10a455'), 
('9b7d561d-7f31-4880-ab9e-86bceaf95d24'), 
('9bd03253-a9ff-4f22-8c63-55442e225139'), 
('a092311a-2637-4446-875a-16fed8ab1038'), 
('a2a15298-272b-4399-a3b1-f654901754c7'), 
('a33ab479-53de-4952-92bd-64af0046b125'), 
('a370e014-2e3b-47e7-9bbb-157f71bbfb8c'), 
('a4a7c702-4b79-4d0a-9666-4803605510e7'), 
('a971d527-520f-4f30-9320-4b3a34d1dedc'), 
('ac38e0b5-670d-4266-a0ac-e29b2d116407'), 
('b0253df1-8e74-409a-b35c-87b7f49021df'), 
('b6587260-3b82-4ae0-9017-d4725cc463a2'), 
('b65a9a27-6169-4a4f-b14a-2c4bc8b09d60'), 
('b688d761-f2ec-4ae9-b1f2-8439e3b5f6c7'), 
('b873057a-15f5-4565-a2bc-3f3f559724f7'), 
('bdd275dc-5267-4191-a7bc-6055ddb10d16'), 
('bded420e-fb3f-4b24-85b6-40328e2f078f'), 
('c36d986e-ab58-4411-ba12-97ba2f42abda'), 
('c4cb0146-dad6-4a1b-b6e4-b1f38b62fc64'), 
('c7b6a3d0-1507-4253-8576-07cf5ee2251e'), 
('cba00b4c-ed7d-46e0-9473-6ad31a1073f4'), 
('cc6f249d-9821-4530-ad33-5ea8f7e16924'), 
('cd99afed-78aa-4f1d-962f-f8ef7cf88b51'), 
('ce7868ec-418a-4edb-a8be-0b2be284cd6e'), 
('cfd74446-91f2-4681-98c3-6ce186bce1b1'), 
('d5327643-e78e-4789-a8c1-5128788c3f6a'), 
('d71ddaf8-242e-41cc-a862-1ed7a1d11cb6'), 
('d867c0d8-6ebb-4cd4-b376-4bce2cde187a'), 
('d899dbf0-72a5-404f-8999-903b53c2bce1'), 
('dbba1f9c-c3b0-4e2b-be6a-50613f0c8270'), 
('dcf85e6f-1482-4539-93fb-12932dc86d40'), 
('dd416a32-1344-4bba-b2c7-9b1d9e0dd6f4'), 
('e055964e-0cfa-44d4-9bc4-2bbfe6d35eb4'), 
('e0a5c494-e096-47f2-be5a-4db121926fd5'), 
('e1a71180-f30d-4d1e-bf1a-fdf8f5a801b9'), 
('e31a4d9a-5998-449f-8721-5764d9bd34fe'), 
('e8854ddf-78ae-409b-b0a6-c87cb0edd88a'), 
('e897a66f-b732-4f3e-84cc-e87652c95720'), 
('eb88f26a-9e57-4c3a-9494-7fbbea571dc5'), 
('eb8aed5f-5e4f-43ae-980f-a982c981b14f'), 
('ed377bcb-d7d5-4725-9e5c-b4c666a50fb7'), 
('ee5c9ee0-fd50-4765-98a3-85674f4594a3'), 
('ef0c8d69-df7d-4e50-997c-5192a65579fa'), 
('fa980092-994e-4a29-a80c-a8f6d2621e0d'), 
('fded235e-ae44-41f4-ac4d-49f26e1888c5')