ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK__Supplier__Profil__2D27B809] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ID])
GO

ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK__Supplier__Profil__2D27B809]