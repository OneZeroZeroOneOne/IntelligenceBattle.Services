using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class intelligencebattleContext : DbContext
    {
        public intelligencebattleContext()
        {
        }

        public intelligencebattleContext(DbContextOptions<intelligencebattleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AuthorizationCenter> AuthorizationCenters { get; set; }
        public virtual DbSet<AuthorizationProvider> AuthorizationProviders { get; set; }
        public virtual DbSet<AuthorizationProviderType> AuthorizationProviderTypes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameQuestion> GameQuestions { get; set; }
        public virtual DbSet<GameType> GameTypes { get; set; }
        public virtual DbSet<GameTypeTranslation> GameTypeTranslations { get; set; }
        public virtual DbSet<GameUser> GameUsers { get; set; }
        public virtual DbSet<Lang> Langs { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationType> NotificationTypes { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<SearchGame> SearchGames { get; set; }
        public virtual DbSet<SendQuestion> SendQuestions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAnswer> UserAnswers { get; set; }
        public virtual DbSet<UserSecurity> UserSecurities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=185.87.48.116;Port=5434;Database=intelligencebattle;Username=postgres;Password=123123AAA");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.Text).HasColumnType("character varying");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("Answer_QuestionId_fkey");
            });

            modelBuilder.Entity<AuthorizationCenter>(entity =>
            {
                entity.ToTable("AuthorizationCenter");

                entity.Property(e => e.Title).HasColumnType("character varying");
            });

            modelBuilder.Entity<AuthorizationProvider>(entity =>
            {
                entity.ToTable("AuthorizationProvider");

                entity.Property(e => e.Key).HasColumnType("character varying");

                entity.HasOne(d => d.AuthorizationProviderType)
                    .WithMany(p => p.AuthorizationProviders)
                    .HasForeignKey(d => d.AuthorizationProviderTypeId)
                    .HasConstraintName("AuthorizationProvider_AuthorizationProviderTypeId_fkey");
            });

            modelBuilder.Entity<AuthorizationProviderType>(entity =>
            {
                entity.ToTable("AuthorizationProviderType");

                entity.Property(e => e.Title).HasColumnType("character varying");

                entity.HasOne(d => d.AuthorizationProviderCenter)
                    .WithMany(p => p.AuthorizationProviderTypes)
                    .HasForeignKey(d => d.AuthorizationProviderCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AuthorizationProviderType_AuthorizationProviderCenterId_fkey");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('category_id_seq'::regclass)");

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<CategoryTranslation>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.LangId })
                    .HasName("CategoryTranslation_pkey");

                entity.ToTable("CategoryTranslation");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryTranslations)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CategoryTranslation_CategoryId_fkey");

                entity.HasOne(d => d.Lang)
                    .WithMany(p => p.CategoryTranslations)
                    .HasForeignKey(d => d.LangId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CategoryTranslation_LangId_fkey");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");

                entity.Property(e => e.CreatedDatetime).HasPrecision(6);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Game_CategoryId_fkey");

                entity.HasOne(d => d.GameType)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.GameTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Game_GameTypeId_fkey");
            });

            modelBuilder.Entity<GameQuestion>(entity =>
            {
                entity.HasKey(e => new { e.QuestionId, e.GameId })
                    .HasName("GameQuestion_pkey");

                entity.ToTable("GameQuestion");

                entity.Property(e => e.IsCurrent).HasColumnName("IsCurrent ");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameQuestions)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GameQuestion_GameId_fkey");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.GameQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GameQuestion_QuestionId_fkey");
            });

            modelBuilder.Entity<GameType>(entity =>
            {
                entity.ToTable("GameType");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('game_type_id_seq'::regclass)");

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<GameTypeTranslation>(entity =>
            {
                entity.HasKey(e => new { e.GameTypeId, e.LangId })
                    .HasName("GameTypeTranslation_pkey");

                entity.ToTable("GameTypeTranslation");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.GameType)
                    .WithMany(p => p.GameTypeTranslations)
                    .HasForeignKey(d => d.GameTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GameTypeTranslation_GameTypeId_fkey");

                entity.HasOne(d => d.Lang)
                    .WithMany(p => p.GameTypeTranslations)
                    .HasForeignKey(d => d.LangId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GameTypeTranslation_LangId_fkey");
            });

            modelBuilder.Entity<GameUser>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.UserId })
                    .HasName("GameUser_pkey");

                entity.ToTable("GameUser");

                entity.Property(e => e.CreatedDateTime).HasPrecision(6);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameUsers)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GameUser_GameId_fkey");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.GameUsers)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GameUser_ProviderId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GameUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GameUser_UserId_fkey");
            });

            modelBuilder.Entity<Lang>(entity =>
            {
                entity.ToTable("Lang");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsRequired();
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('notification_id_seq'::regclass)");

                entity.Property(e => e.Text).IsRequired();

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Notification_TypeId_fkey");
            });

            modelBuilder.Entity<NotificationType>(entity =>
            {
                entity.ToTable("NotificationType");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('notification_type_id_seq'::regclass)");

                entity.Property(e => e.Tittle).HasMaxLength(255);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.CreatedDatetime).HasPrecision(6);

                entity.Property(e => e.Text).HasColumnType("character varying");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Question_CategoryId_fkey");
            });

            modelBuilder.Entity<SearchGame>(entity =>
            {
                entity.ToTable("SearchGame");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('search_game_id_seq'::regclass)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SearchGames)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SearchGame_CategoryId_fkey");

                entity.HasOne(d => d.GameType)
                    .WithMany(p => p.SearchGames)
                    .HasForeignKey(d => d.GameTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SearchGame_GameTypeId_fkey");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.SearchGames)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SearchGame_ProviderId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SearchGames)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SearchGame_UserId_fkey");
            });

            modelBuilder.Entity<SendQuestion>(entity =>
            {
                entity.ToTable("SendQuestion");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('send_question_id_seq'::regclass)");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.SendQuestions)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SendQuestion_GameId_fkey");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.SendQuestions)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SendQuestion_ProviderId_fkey");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.SendQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SendQuestion_QuestionId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SendQuestions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SendQuestion_UserId_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.CreatedDatetime).HasPrecision(6);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<UserAnswer>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GameId, e.QuestionId })
                    .HasName("UserAnswer_pkey");

                entity.ToTable("UserAnswer");

                entity.Property(e => e.CreatedDatetime).HasPrecision(6);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("UserAnswer_AnswerId_fkey");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAnswer_GameId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAnswer_UserId_fkey");
            });

            modelBuilder.Entity<UserSecurity>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RealId })
                    .HasName("UserSecurity_pkey");

                entity.ToTable("UserSecurity");

                entity.Property(e => e.Login).HasColumnType("character varying");

                entity.Property(e => e.Password).HasColumnType("character varying");

                entity.HasOne(d => d.AuthorizationCenter)
                    .WithMany(p => p.UserSecurities)
                    .HasForeignKey(d => d.AuthorizationCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserSecurity_AuthorizationCenterId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSecurities)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserSecurity_UserId_fkey");
            });

            modelBuilder.HasSequence("category_id_seq");

            modelBuilder.HasSequence("game_type_id_seq");

            modelBuilder.HasSequence("notification_id_seq");

            modelBuilder.HasSequence("notification_type_id_seq");

            modelBuilder.HasSequence("search_game_id_seq");

            modelBuilder.HasSequence("send_question_id_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
