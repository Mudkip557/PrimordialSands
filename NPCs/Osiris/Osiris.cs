using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using PrimordialSands.Projectiles;

namespace PrimordialSands.NPCs.Osiris
{
    public class Osiris : ModNPC
    {
        public int dashTimer = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Osiris, Ethereal Scourge");
            Main.npcFrameCount[npc.type] = 1;
        }
        
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.damage = 62;
            npc.defense = 30;
            npc.lifeMax = 24000;
            npc.width = 120;
            npc.height = 120;
            npc.knockBackResist = 0f;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.boss = true;
            npc.HitSound = SoundID.NPCHit34;
            npc.DeathSound = SoundID.NPCDeath20;
            npc.value = Terraria.Item.buyPrice(0, 15, 0, 0);
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/OneThousandDeadlyStares");
            bossBag = mod.ItemType("OsirisBag");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.38f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.45f);
        }
        public int Change = 0;
        int num101 = 1;
        int soulCount = 0;
        public override void AI()
        {
            int damage = 34;
            npc.rotation = npc.velocity.X / 30f;
            Player player = Main.player[npc.target];
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.velocity = new Vector2(0f, -10f);
                    if (npc.timeLeft > 150 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.timeLeft = 150;
                        npc.netUpdate = true;
                    }
                    return;
                }
            }
            else if (npc.timeLeft > 1800 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                npc.timeLeft = 1800;
                npc.netUpdate = true;
            }
            if (soulCount == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                int num132 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Soul>());
                Main.npc[num132].ai[1] = 0;
                int num133 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Soul>());
                Main.npc[num133].ai[1] = 180;
                npc.netUpdate = true;
                soulCount = 1;
            }
            if (npc.ai[3] != 1 || npc.ai[3] != 3)
            {
                npc.TargetClosest(true);
                float num677 = 15f;
                float num678 = 0.12f;
                if ((double)npc.life < (double)npc.lifeMax * 0.80)
                {
                    num677 = 16f;
                    num678 = 0.13f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.60)
                {
                    num677 = 17f;
                    num678 = 0.15f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.40)
                {
                    num677 = 18f;
                    num678 = 0.18f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.20)
                {
                    num677 = 19f;
                    num678 = 0.2f;
                }
                Vector2 vector87 = new Vector2(npc.Center.X, npc.Center.Y);
                float num679 = Main.player[npc.target].Center.X - vector87.X;
                float num680 = Main.player[npc.target].Center.Y - vector87.Y - 250f;
                float num681 = (float)Math.Sqrt((double)(num679 * num679 + num680 * num680));
                num681 = num677 / num681;
                num679 *= num681;
                num680 *= num681;

                if (npc.velocity.X < num679)
                {
                    npc.velocity.X = npc.velocity.X + num678;
                    if (npc.velocity.X < 0f && num679 > 0f && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.velocity.X = npc.velocity.X + num678;
                        npc.netUpdate = true;
                    }
                }
                else if (npc.velocity.X > num679)
                {
                    npc.velocity.X = npc.velocity.X - num678;
                    if (npc.velocity.X > 0f && num679 < 0f && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.velocity.X = npc.velocity.X - num678;
                        npc.netUpdate = true;
                    }
                }
                if (npc.velocity.Y < num680)
                {
                    npc.velocity.Y = npc.velocity.Y + num678;
                    if (npc.velocity.Y < 0f && num680 > 0f && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.velocity.Y = npc.velocity.Y + num678;
                        npc.netUpdate = true;
                    }
                }
                else if (npc.velocity.Y > num680)
                {
                    npc.velocity.Y = npc.velocity.Y - num678;
                    if (npc.velocity.Y > 0f && num680 < 0f && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.velocity.Y = npc.velocity.Y - num678;
                        npc.netUpdate = true;
                    }
                }
            }
            int Attack1 = 127;
            int Attack2 = 240;
            int Attack3 = 193;
            if ((double)npc.life < (double)npc.lifeMax * 0.80)
            {
                Attack1 = 114;
                Attack2 = 224;
                Attack3 = 183;
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.60)
            {
                Attack1 = 98;
                Attack2 = 208;
                Attack3 = 163;
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.40)
            {
                Attack1 = 72;
                Attack2 = 160;
                Attack3 = 153;
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.20)
            {
                Attack1 = 62;
                Attack2 = 140;
                Attack3 = 143;
            }
            if (npc.ai[3] == 0)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.dontTakeDamage = false;
                    npc.netUpdate = true;
                }
                Change += 1;
                if (Change >= 549 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[3] = 1;
                    Change = 0;
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                    Attack1 = 0;
                    Attack2 = 0;
                    Attack3 = 0;
                }
                npc.ai[0] += 1;
                npc.ai[1] += 1;
                npc.ai[2] += 1;
                if (npc.ai[0] == Attack1 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.netUpdate = true;
                    float Speed = 5f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                    int type = ProjectileID.LostSoulHostile;
                    float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                }
                if (npc.ai[0] >= (int)(Attack1 += 5) && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.netUpdate = true;
                    float Speed = 5f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                    int type = ProjectileID.LostSoulHostile;
                    float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    npc.ai[0] = 0;
                }
                if (npc.ai[1] >= Attack2 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[1] = 0;
                    npc.netUpdate = true;
                    Vector2 vector23 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float num147 = 11f;
                    float num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                    float num149 = Math.Abs(num148) * 0.1f;
                    float num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y - num149;
                    float num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                    npc.netUpdate = true;
                    num151 = num147 / num151;
                    num148 *= num151;
                    num150 *= num151;
                    int num25;
                    Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 73);
                    for (int num154 = 0; num154 < 9; num154 = num25 + 1)
                    {
                        num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                        num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y;
                        num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                        num151 = 12f / num151;
                        num148 += (float)Main.rand.Next(-50, 51);
                        num150 += (float)Main.rand.Next(-50, 51);
                        num148 *= num151;
                        num150 *= num151;
                        Projectile.NewProjectile(vector23.X, vector23.Y, num148, num150, ProjectileID.CultistBossFireBall, damage, 0f, Main.myPlayer, 0f, 0f);
                        num25 = num154;
                    }
                }
                if (npc.ai[2] >= Attack3 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.netUpdate = true;
                    npc.ai[2] = 0;
                    Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 73);
                    float Speed = 10f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                    int type = ProjectileID.CultistBossFireBall;
                    float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                }
            }
            if (npc.ai[3] == 1 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                npc.ai[0] += 1;
                if (Main.rand.Next(16) == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Projectile.NewProjectile(npc.position.X + Main.rand.Next(-50, 51), npc.position.Y + Main.rand.Next(-50, 51), 0f, 0f, mod.ProjectileType("soulCountBomb"), damage, 0f, Main.myPlayer, 0f, 0f);
                    npc.netUpdate = true;
                }
                if (Main.rand.Next(16) == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Projectile.NewProjectile(npc.position.X + Main.rand.Next(-50, 51), npc.position.Y + Main.rand.Next(-50, 51), 0f, 0f, mod.ProjectileType("soulCountSpawn"), damage, 0f, Main.myPlayer, 0f, 0f);
                    npc.netUpdate = true;
                }
                if (npc.ai[0] >= 100 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[3] = (int)(npc.ai[3] += num101);
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                    npc.netUpdate = true;
                }
                npc.velocity.X *= 0.9f;
                npc.velocity.Y *= 0.9f;
            }
            int num333 = 40;
            if ((double)npc.life < (double)npc.lifeMax * 0.80 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num333 = 37;
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.60 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num333 = 35;
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.40 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num333 = 32;
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.20 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num333 = 30;
            }
            int choice = 0;
            int choosing = 0;
            if (npc.ai[3] == 2)
            {
                if (choosing == 0)
                {
                    choosing = 1;
                    choice = Main.rand.Next(2);
                }
                if (choice == 0)
                {
                    npc.ai[1] += 1;
                    if (npc.ai[1] == (int)(num333) && Main.netMode != NetmodeID.MultiplayerClient) // dual shot
                    {
                        npc.netUpdate = true;
                        float Speed = 8f;  // projectile speed
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                        int type = 291;  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    }
                    if (npc.ai[1] == (int)(num333 += 8) && Main.netMode != NetmodeID.MultiplayerClient) // dual shot
                    {
                        npc.netUpdate = true;
                        float Speed = 8f;  // projectile speed
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                        int type = 291;  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    }
                    if (npc.ai[1] >= (int)(num333 += 18) && Main.netMode != NetmodeID.MultiplayerClient) // dual shot
                    {
                        npc.netUpdate = true;
                        float Speed = 8f;  // projectile speed
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                        int type = 291;  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                        npc.ai[0] = 0;
                        npc.ai[2] += 1;
                    }
                    if (npc.ai[2] >= 15 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.ai[3] = 0;
                        npc.ai[0] = 0;
                        choosing = 0;
                        npc.netUpdate = true;
                        npc.ai[1] = 0;
                        choice = 0;
                        npc.ai[2] = 0;
                        num101 += 1;
                        Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 14);
                        int num3;
                        for (int num624 = 0; num624 < 100; num624 = num3 + 1)
                        {
                            int num625 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 127, 0f, 0f, 0, default(Color), 2f);
                            Dust dust = Main.dust[num625];
                            dust.velocity *= 2.5f;
                            dust = Main.dust[num625];
                            dust.scale *= 0.9f;
                            Main.dust[num625].noGravity = true;
                            num3 = num624;
                        }
                        int num11 = Main.rand.Next(8, 10);
                        for (int j = 0; j < num11; j++)
                        {
                            Vector2 vector5 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                            vector5 += npc.velocity * 3f;
                            vector5.Normalize();
                            vector5 *= (float)Main.rand.Next(35, 39) * 0.1f;

                            int dab = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector5.X, vector5.Y, ProjectileID.BallofFire, 40, 0f, Main.myPlayer);
                            Main.projectile[dab].hostile = true;
                            Main.projectile[dab].friendly = false;
                        }

                        int num12 = Main.rand.Next(8, 10);
                        for (int g = 0; g < num11; g++)
                        {
                            Vector2 vector5 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                            vector5 += npc.velocity * 3f;
                            vector5.Normalize();
                            vector5 *= (float)Main.rand.Next(35, 39) * 0.1f;

                            int dab = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector5.X, vector5.Y, ProjectileID.GreekFire3, 40, 0f, Main.myPlayer);
                            Main.projectile[dab].hostile = true;
                            Main.projectile[dab].friendly = false;
                        }

                    }
                }
                if (choice == 1)
                {
                    int num11 = Main.rand.Next(6, 8);
                    npc.ai[1] += 1;
                    if (Main.rand.Next(30) == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        for (int g = 0; g < num11; g++)
                        {
                            Projectile.NewProjectile(player.position.X - Main.rand.Next(1, 350), player.position.Y - 600, 0f, 4f, ProjectileType<SoulProjectile>(), damage, 0f, Main.myPlayer);
                            Projectile.NewProjectile(player.position.X + Main.rand.Next(1, 350), player.position.Y - 600, 0f, 4f, ProjectileType<SoulProjectile>(), damage, 0f, Main.myPlayer);
                        }
                        npc.ai[0] += 1;
                        npc.netUpdate = true;
                    }
                    if (npc.ai[0] >= 14 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.ai[3] = 0;
                        npc.netUpdate = true;
                        npc.ai[0] = 0;
                        npc.ai[1] = 0;
                        npc.ai[2] = 0;
                        choosing = 0;
                        choice = 0;
                        num101 += 1;
                    }
                }
            }
            int num335 = 80;
            int num336 = 28;
            int num337 = 8;
            if ((double)npc.life < (double)npc.lifeMax * 0.80 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num335 = 70;
                num336 = 25;
                num337 = 9;
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.60 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num335 = 60;
                num336 = 23;
                num337 = 10;
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.40 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num335 = 50;
                num336 = 20;
                num337 = 12;
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.20 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num335 = 40;
                num336 = 16;
                num337 = 14;
            }
            if (npc.ai[3] == 3)
            {
                if (choosing == 0)
                {
                    choosing = 1;
                    choice = Main.rand.Next(2);
                }
                if (choice == 0)
                {
                    npc.ai[1] += 1;
                    if (npc.ai[1] >= num335 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.ai[2] += 1;
                        npc.ai[1] = 0;
                        npc.netUpdate = true;
                        Vector2 vector23 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float num147 = 11f;
                        float num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                        float num149 = Math.Abs(num148) * 0.1f;
                        float num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y - num149;
                        float num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                        npc.netUpdate = true;
                        num151 = num147 / num151;
                        num148 *= num151;
                        num150 *= num151;
                        int num25;
                        for (int num154 = 0; num154 < 9; num154 = num25 + 1)
                        {
                            num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                            num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y;
                            num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                            num151 = 12f / num151;
                            num148 += (float)Main.rand.Next(-60, 61);
                            num150 += (float)Main.rand.Next(-60, 61);
                            num148 *= num151;
                            num150 *= num151;
                            Projectile.NewProjectile(vector23.X, vector23.Y, num148, num150, mod.ProjectileType("soulCountCrystal"), damage, 0f, Main.myPlayer, 0f, 0f);
                            num25 = num154;
                        }

                    }
                    if (npc.ai[2] >= num337 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.ai[3] = 0;
                        npc.ai[0] = 0;
                        npc.ai[1] = 0;
                        npc.netUpdate = true;
                        choice = 0;
                        choosing = 0;
                        npc.ai[2] = 0;
                        num101 += 1;
                    }
                }
                if (choice == 1)
                {
                    npc.ai[1] += 1;
                    if (npc.ai[1] == num336 && Main.netMode != NetmodeID.MultiplayerClient) //fireball spam
                    {
                        npc.ai[1] = 0;
                        npc.ai[2] += 1;
                        npc.netUpdate = true;
                        float Speed = 8f;  // projectile speed
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                        int type = 291;  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    }
                    if (npc.ai[2] >= num337 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.ai[3] = 0;
                        npc.ai[0] = 0;
                        npc.ai[1] = 0;
                        choice = 0;
                        choosing = 0;
                        npc.ai[2] = 0;
                        npc.netUpdate = true;
                        num101 += 1;
                    }
                }
            }
            int num338 = 110;
            int num339 = 8;
            if ((double)npc.life < (double)npc.lifeMax * 0.80 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num338 = 100;
                num339 = 9;
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.60 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num338 = 90;
                num339 = 10;
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.40 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num338 = 80;
                num339 = 12;
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.20 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num338 = 65;
                num339 = 14;
            }
            if (npc.ai[3] == 4)
            {
                if (choosing == 0)
                {
                    choosing = 1;
                    choice = Main.rand.Next(2);
                }
                npc.velocity.X *= 0.75f;
                npc.velocity.Y *= 0.75f;
                if (choice == 0)
                {
                    npc.ai[1] += 1;
                    if (npc.ai[1] >= 300 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.ai[3] = 0;
                        npc.ai[0] = 0;
                        choice = 0;
                        choosing = 0;
                        npc.ai[1] = 0;
                        npc.ai[2] = 0;
                        num101 += 1;
                        npc.netUpdate = true;
                    }
                    if (Main.rand.Next(10) == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.netUpdate = true;
                        Projectile.NewProjectile(player.position.X + 1200, player.position.Y + Main.rand.Next(800) - 400, -4f, 0f, mod.ProjectileType("soulCountCrystal"), damage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X - 1200, player.position.Y + Main.rand.Next(800) - 400, 4f, 0f, mod.ProjectileType("soulCountCrystal"), damage, 0f, Main.myPlayer);
                    }
                }
                if (choice == 1)
                {
                    npc.ai[1] += 1;
                    if (npc.ai[1] == num338 && Main.netMode != NetmodeID.MultiplayerClient) //fireball spam
                    {
                        npc.ai[1] = 0;
                        npc.ai[2] += 1;
                        Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 73);
                        npc.netUpdate = true;
                        float Speed = 8f;  // projectile speed
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                        int type = mod.ProjectileType("BurningBallofFire");  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    }
                    if (npc.ai[2] >= num339 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.ai[3] = 0;
                        npc.netUpdate = true;
                        npc.ai[0] = 0;
                        npc.ai[1] = 0;
                        choice = 0;
                        choosing = 0;
                        npc.ai[2] = 0;
                        num101 += 1;
                    }
                }
            }

            int num340 = 120;
            if ((double)npc.life < (double)npc.lifeMax * 0.80 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num340 = 90;
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.60 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num340 = 75;
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.40 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num340 = 70;
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.20 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                num340 = 60;
            }
            if (npc.ai[3] == 5)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.dontTakeDamage = true;
                    npc.netUpdate = true;
                }
                npc.ai[1] += 1;
                npc.ai[2] += 1;
                if (npc.ai[2] >= num340 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 73);
                    npc.ai[2] = 0;
                    npc.netUpdate = true;
                    float Speed = 8f;  // projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                    int type = mod.ProjectileType("BurningBallofFire");  //put your projectile
                    float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);

                    Vector2 vector23 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float num147 = 11f;
                    float num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                    float num149 = Math.Abs(num148) * 0.1f;
                    float num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y - num149;
                    float num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                    npc.netUpdate = true;
                    num151 = num147 / num151;
                    num148 *= num151;
                    num150 *= num151;
                    int num25;
                    for (int num154 = 0; num154 < 9; num154 = num25 + 1)
                    {
                        num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                        num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y;
                        num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                        num151 = 12f / num151;
                        num148 += (float)Main.rand.Next(-70, 71);
                        num150 += (float)Main.rand.Next(-70, 71);
                        num148 *= num151;
                        num150 *= num151;
                        Projectile.NewProjectile(vector23.X, vector23.Y, num148, num150, mod.ProjectileType("soulCountCrystal"), damage, 0f, Main.myPlayer, 0f, 0f);
                        num25 = num154;
                    }
                }
                if (npc.ai[1] >= 1200 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[3] = 0;
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    choice = 0;
                    choosing = 0;
                    npc.ai[2] = 0;
                    npc.netUpdate = true;
                    num101 = 1;
                }

            }
        } //Extremely messy code, needs to be  cleaned up.
    }
}