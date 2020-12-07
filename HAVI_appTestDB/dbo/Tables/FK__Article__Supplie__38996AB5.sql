ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK__Article__Supplie__38996AB5] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([ID])
GO

ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK__Article__Supplie__38996AB5]