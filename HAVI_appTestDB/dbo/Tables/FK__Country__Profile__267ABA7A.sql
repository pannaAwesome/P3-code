﻿ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK__Country__Profile__267ABA7A] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK__Country__Profile__267ABA7A]