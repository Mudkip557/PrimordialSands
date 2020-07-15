using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;

namespace PrimordialSands.NPCs.IndenwoodTreant
{
    [AutoloadBossHead]
    public class EngulfedTreant : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Engulfed Treant");
            Main.npcFrameCount[npc.type] = 14;
        }
        public override void SetDefaults()
        {
            NPCID.Sets.TrailCacheLength[npc.type] = 5;
            npc.damage = 22;
            npc.npcSlots = 5f;
            npc.width = 62;
            npc.height = 180;
            npc.defense = 12;
            npc.lifeMax = 3000;
            npc.aiStyle = -1;
            npc.knockBackResist = 0f;
            npc.value = Item.buyPrice(0, 2, 0, 0);
            npc.buffImmune[39] = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[20] = true;
            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit19;
            npc.DeathSound = SoundID.NPCDeath45;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/The_Jungles_Den");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = (int)(npc.damage * 1.2f * numPlayers); //only feels more balanced
            npc.defense = (int)(npc.defense * 1.2f * numPlayers);
            npc.lifeMax = (int)(npc.lifeMax / Main.expertLife * 1.2f * bossLifeScale);
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.2f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        float AI2 = 0;
        float nutty = 20;
        public override void AI()
        {
            #region messy code
            Player player = Main.player[npc.target];
            int damage = npc.damage;
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
                npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 0.785f;
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.velocity = new Vector2(0f, -10f);
                    if (npc.timeLeft > 150)
                    {
                        npc.timeLeft = 150;
                    }
                    return;
                }
            }
            if (Main.player[npc.target].dead)
            {
                npc.ai[3] = 20;
                npc.velocity.X = 0f;
                npc.velocity.Y += 2f;
            }
            npc.rotation = npc.velocity.X * 0.01f;
            if (!Main.player[npc.target].dead)
            {

                if (npc.ai[3] == 0)
                {
                    float num = 5f;
                    float velocity2 = 0.17f;
                    if ((double)npc.life < (double)npc.lifeMax * 0.75)
                    {
                        num = 7f;
                    }
                    if ((double)npc.life < (double)npc.lifeMax * 0.5)
                    {
                        num = 8f;
                    }
                    if ((double)npc.life < (double)npc.lifeMax * 0.25)
                    {
                        num = 10f;
                    }
                    Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float playerX = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
                    float playerY = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
                    playerX = (float)((int)(playerX / 8f) * 8);
                    playerY = (float)((int)(playerY / 8f) * 8);
                    vector.X = (float)((int)(vector.X / 8f) * 8);
                    vector.Y = (float)((int)(vector.Y / 8f) * 8);
                    playerX -= vector.X;
                    playerY -= vector.Y;
                    float playerCubed = (float)Math.Sqrt((double)(playerX * playerX + playerY * playerY));
                    float num7 = playerCubed;
                    if (playerCubed == 0f)
                    {
                        playerX = npc.velocity.X;
                        playerY = npc.velocity.Y;
                    }
                    else
                    {
                        playerCubed = num / playerCubed;
                        playerX *= playerCubed;
                        playerY *= playerCubed;
                    }
                    if (npc.velocity.X < playerX)
                    {
                        npc.velocity.X = npc.velocity.X + velocity2;
                    }
                    else if (npc.velocity.X > playerX)
                    {
                        npc.velocity.X = npc.velocity.X - velocity2;
                    }
                    if (npc.velocity.Y < playerY)
                    {
                        npc.velocity.Y = npc.velocity.Y + velocity2;
                    }
                    else if (npc.velocity.Y > playerY)
                    {
                        npc.velocity.Y = npc.velocity.Y - velocity2;
                    }
                }

                if (npc.ai[3] == 2 && Main.netMode != NetmodeID.MultiplayerClient)
                {

                    if (AI2 == 0f)
                    {

                        if (npc.Center.X < Main.player[npc.target].Center.X && Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            AI2 = 1f;
                        }
                        else
                        {
                            AI2 = -1f;
                        }
                    }

                    int num852 = 800;
                    float num853 = Math.Abs(npc.Center.X - Main.player[npc.target].Center.X);
                    if (npc.Center.X < Main.player[npc.target].Center.X && AI2 < 0f && num853 > (float)num852 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        AI2 = 0f;
                    }
                    if (npc.Center.X > Main.player[npc.target].Center.X && AI2 > 0f && num853 > (float)num852 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        AI2 = 0f;
                    }
                    float num854 = 0.45f;
                    float num855 = 7f;
                    if ((double)npc.life < (double)npc.lifeMax * 0.75 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        num854 = 0.55f;
                        npc.netUpdate = true;
                        num855 = 8f;
                    }
                    if ((double)npc.life < (double)npc.lifeMax * 0.5 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        num854 = 0.7f;
                        npc.netUpdate = true;
                        num855 = 10f;
                    }
                    if ((double)npc.life < (double)npc.lifeMax * 0.25 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        num854 = 0.8f;
                        npc.netUpdate = true;
                        num855 = 11f;
                    }
                    npc.velocity.X = npc.velocity.X + AI2 * num854;
                    if (npc.velocity.X > num855 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.velocity.X = num855;
                        npc.netUpdate = true;
                    }
                    if (npc.velocity.X < -num855 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.velocity.X = -num855;
                        npc.netUpdate = true;
                    }
                    float num856 = Main.player[npc.target].position.Y - (npc.position.Y + (float)npc.height);
                    if (num856 < 150f && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.velocity.Y = npc.velocity.Y - 0.2f;
                        npc.netUpdate = true;
                    }
                    if (num856 > 200f && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.velocity.Y = npc.velocity.Y + 0.2f;
                        npc.netUpdate = true;
                    }
                    if (npc.velocity.Y > 8f && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.velocity.Y = 8f;
                        npc.netUpdate = true;
                    }
                    if (npc.velocity.Y < -8f && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.velocity.Y = -8f;
                        npc.netUpdate = true;
                    }

                }
            }

            if (npc.ai[3] == 0)
            {
                npc.ai[0] += 1;
                int velocity235 = 21;
                if ((double)npc.life <= (double)npc.lifeMax * 0.75 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    velocity235 = 19;
                    npc.netUpdate = true;
                }
                if ((double)npc.life <= (double)npc.lifeMax * 0.50 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    velocity235 = 16;
                    npc.netUpdate = true;
                }
                if ((double)npc.life <= (double)npc.lifeMax * 0.25 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    velocity235 = 13;
                    npc.netUpdate = true;
                }
                if (Main.expertMode)
                {
                    if (Main.rand.Next(velocity235) == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Projectile.NewProjectile(npc.position.X + Main.rand.Next(-50, 51), npc.position.Y + Main.rand.Next(-50, 51), 0f, 0f, mod.ProjectileType("PlagueMine"), damage, 0f, Main.myPlayer, 0f, 0f);
                        npc.netUpdate = true;
                    }
                }
                else
                {
                    if (Main.rand.Next(17) == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Projectile.NewProjectile(npc.position.X + Main.rand.Next(-50, 51), npc.position.Y + Main.rand.Next(-50, 51), 0f, 0f, mod.ProjectileType("PlagueMine"), damage, 0f, Main.myPlayer, 0f, 0f);
                        npc.netUpdate = true;
                    }
                }
                if (npc.ai[0] >= 200)
                {
                    npc.ai[3] = 1;
                    npc.ai[0] = 0;
                    npc.netUpdate = true;
                }
            }


            if (npc.ai[3] == 1)
            {
                npc.ai[0] += 1;
                npc.velocity.X *= 0.9f;
                npc.velocity.Y *= 0.9f;
                int num3 = 100;
                int playerX = 120;
                int playerY = 125;
                if ((double)npc.life <= (double)npc.lifeMax * 0.75 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    num3 = 90;
                    num3 = 110;
                    num3 = 115;
                    npc.netUpdate = true;
                }
                if ((double)npc.life <= (double)npc.lifeMax * 0.50 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    num3 = 80;
                    num3 = 100;
                    num3 = 105;
                    npc.netUpdate = true;
                }
                if ((double)npc.life <= (double)npc.lifeMax * 0.25 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    num3 = 70;
                    num3 = 80;
                    num3 = 85;
                    npc.netUpdate = true;
                }
                if (npc.ai[0] == num3 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.position.X = player.position.X - 10 + Main.rand.Next(11);
                    npc.position.Y = player.position.Y - 10 + Main.rand.Next(11);
                    for (int num623 = 0; num623 < 25; num623++)
                    {
                        int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 1.6f);
                        Main.dust[num624].noGravity = true;
                        Main.dust[num624].velocity *= 4f;
                    }
                    npc.netUpdate = true;
                }
                if (npc.ai[0] == (int)(num3 += 1))
                {
                    for (int num623 = 0; num623 < 25; num623++)
                    {
                        int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 1.6f);
                        Main.dust[num624].noGravity = true;
                        Main.dust[num624].velocity *= 4f;
                    }
                }
                if (npc.ai[0] == playerX && npc.ai[1] == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[0] = 0;
                    npc.ai[1] = 1;
                    npc.ai[3] = 2;
                    npc.netUpdate = true;
                }
                else if (npc.ai[0] == playerY && npc.ai[1] == 1 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    npc.ai[3] = 3;
                    npc.netUpdate = true;
                }
            }
            if (npc.ai[3] == 2)
            {
                int num1 = 8;
                int velocity2 = 25;
                if ((double)npc.life <= (double)npc.lifeMax * 0.75 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    num1 = 10;
                    velocity2 = 20;
                    npc.netUpdate = true;
                }
                if ((double)npc.life <= (double)npc.lifeMax * 0.50 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    num1 = 12;
                    velocity2 = 15;
                    npc.netUpdate = true;
                }
                if ((double)npc.life <= (double)npc.lifeMax * 0.25 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    num1 = 14;
                    velocity2 = 13;
                    npc.netUpdate = true;
                }
                npc.ai[0] += 1;
                if (npc.ai[0] >= velocity2)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.ai[0] = 1;
                        npc.ai[2] += 1;
                        float Speed = 9f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
                        int type = mod.ProjectileType("PlagueSplit");
                        float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                        int playerY4 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                        npc.netUpdate = true;
                    }
                }
                if (npc.ai[2] >= num1 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[0] = 0;
                    npc.ai[2] = 0;
                    npc.ai[3] = 4;
                    npc.netUpdate = true;
                }
            }


            if (npc.ai[3] == 3)
            {
                int num1 = 8;
                int velocity2 = 29;
                npc.velocity.X *= 0.9f;
                npc.velocity.Y *= 0.9f;
                if ((double)npc.life <= (double)npc.lifeMax * 0.75 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    num1 = 9;
                    velocity2 = 25;
                    npc.netUpdate = true;
                }
                if ((double)npc.life <= (double)npc.lifeMax * 0.50 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    num1 = 11;
                    velocity2 = 22;
                    npc.netUpdate = true;
                }
                if ((double)npc.life <= (double)npc.lifeMax * 0.25 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    num1 = 13;
                    velocity2 = 18;
                    npc.netUpdate = true;
                }

                npc.ai[0] += 1;
                if (npc.ai[0] >= velocity2 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].head))
                    {
                        if (Main.expertMode && Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            Projectile.NewProjectile(player.position.X, player.position.Y - 600, 0f, 6f, mod.ProjectileType("PlagueStrike1"), damage, 0f, Main.myPlayer);
                            Projectile.NewProjectile(player.position.X, player.position.Y - 600, 0f, 6f, mod.ProjectileType("PlagueStrike2"), damage, 0f, Main.myPlayer);
                            Projectile.NewProjectile(player.position.X, player.position.Y - 600, 0f, 6f, mod.ProjectileType("PlagueLeaf"), damage, 0f, Main.myPlayer);
                            npc.netUpdate = true;
                        }
                        npc.ai[0] = 0;
                        npc.ai[2] += 1;
                        Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 5);
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
                        npc.ai[0] = 0;
                        int velocity25;
                        for (int num154 = 0; num154 < 4; num154 = velocity25 + 1)
                        {
                            num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                            num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y;
                            num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                            num151 = 12f / num151;
                            num148 += (float)Main.rand.Next(-40, 41);
                            num150 += (float)Main.rand.Next(-40, 41);
                            num148 *= num151;
                            num150 *= num151;
                            Projectile.NewProjectile(vector23.X, vector23.Y, num148, num150, mod.ProjectileType("PlagueFeather"), damage, 0f, Main.myPlayer, 0f, 0f);
                            velocity25 = num154;
                        }
                    }
                   
                    else if (nutty == 0)
                    {
                        nutty = 40;
                        npc.position.X = player.position.X - 900 + Main.rand.Next(1800);
                        npc.position.Y = player.position.Y - 900 + Main.rand.Next(1800);
                        for (int i = 0; i < 52; i++)    // More dust
                        {
                            int dustType = 89;
                            int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                            Dust dust = Main.dust[dustIndex];
                            dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                            dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                            dust.scale *= 0.5f;
                        }
                    }
                    npc.netUpdate = true;
                    if (nutty >= 0)
                    {
                        nutty -= 1;
                    }
                }
                if (npc.ai[2] >= num1 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[0] = 0;
                    npc.ai[2] = 0;
                    npc.ai[3] = 4;
                    npc.netUpdate = true;
                }
            }


            if (npc.ai[3] == 4)
            {
                npc.velocity.X *= 0.25f;
                npc.velocity.Y *= 0.25f;
                if (Main.rand.Next(2) == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[3] = 5;
                }
                else
                {
                    npc.ai[3] = 6;
                }
                npc.netUpdate = true;
            }


            if (npc.ai[3] == 5)
            {
                npc.ai[0] += 1;
                if (npc.ai[0] == 50)
                {
                    if (Main.expertMode && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Projectile.NewProjectile(player.position.X, player.position.Y - 600, 0f, 6f, mod.ProjectileType("PlagueStrike1"), damage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X, player.position.Y - 600, 0f, 6f, mod.ProjectileType("PlagueLeaf"), damage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X, player.position.Y - 600, 0f, 6f, mod.ProjectileType("PlagueStrike2"), damage, 0f, Main.myPlayer);
                        npc.netUpdate = true;
                    }
                    npc.position.X = player.position.X - 900 + Main.rand.Next(1800);
                    npc.position.Y = player.position.Y - 900 + Main.rand.Next(1800);
                    for (int num623 = 0; num623 < 25; num623++)
                    {
                        int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 1.6f);
                        Main.dust[num624].noGravity = true;
                        Main.dust[num624].velocity *= 4f;
                    }
                    npc.netUpdate = true;
                }
                if (npc.ai[0] >= 15 && npc.ai[0] <= 35)
                {
                    npc.velocity.X *= 0.95f;
                    npc.velocity.Y *= 0.95f;
                }
                if (npc.ai[0] >= 75 && npc.ai[0] <= 85 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Vector2 PlayerPosition = new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                    PlayerPosition.Normalize();
                    npc.velocity = PlayerPosition * 20f;
                    npc.netUpdate = true;
                }
                if (npc.ai[0] >= 85 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[0] = 0;
                    npc.ai[2] += 1;
                    npc.netUpdate = true;
                }
                if (npc.ai[2] >= 4 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[3] = 0;
                    npc.ai[0] = 0;
                    npc.ai[2] = 0;
                    npc.netUpdate = true;
                }
            }


            if (npc.ai[3] == 6)
            {
                npc.ai[0] += 1;

                if (npc.ai[0] == 50)
                {
                    if (Main.expertMode && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Projectile.NewProjectile(player.position.X, player.position.Y - 600, 0f, 6f, mod.ProjectileType("PlagueStrike1"), damage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X, player.position.Y - 600, 0f, 6f, mod.ProjectileType("PlagueLeaf"), damage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X, player.position.Y - 600, 0f, 6f, mod.ProjectileType("PlagueStrike2"), damage, 0f, Main.myPlayer);
                        npc.netUpdate = true;
                    }
                    npc.position.X = player.position.X - 900 + Main.rand.Next(1800);
                    npc.position.Y = player.position.Y - 900 + Main.rand.Next(1800);
                    for (int num623 = 0; num623 < 25; num623++)
                    {
                        int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 1.6f);
                        Main.dust[num624].noGravity = true;
                        Main.dust[num624].velocity *= 4f;
                    }
                    npc.netUpdate = true;
                }
                if (npc.ai[0] >= 15 && npc.ai[0] <= 35)
                {
                    npc.velocity.X *= 0.95f;
                    npc.velocity.Y *= 0.95f;
                }
                if (npc.ai[0] == 11 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    for (int num623 = 0; num623 < 25; num623++)
                    {
                        int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 1.6f);
                        Main.dust[num624].noGravity = true;
                        Main.dust[num624].velocity *= 4f;
                    }
                    npc.netUpdate = true;
                }

                if (npc.ai[0] >= 75 && npc.ai[0] <= 85 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Vector2 PlayerPosition = new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                    PlayerPosition.Normalize();
                    npc.velocity = PlayerPosition * 20f;
                    npc.netUpdate = true;
                }
                if (npc.ai[0] >= 75 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[0] = 0;
                    npc.ai[2] += 1;
                    npc.netUpdate = true;
                }
                if (npc.ai[2] >= 4 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[3] = 0;
                    npc.ai[0] = 0;
                    npc.ai[2] = 0;
                    npc.netUpdate = true;
                }
            }
            return;
            #endregion
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.npcTexture[npc.type].Width, Main.npcTexture[npc.type].Height * 0.8f);
            for (int k = 0; k < npc.oldPos.Length; k++)
            {
                SpriteEffects effect = npc.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                Color color = npc.GetAlpha(lightColor) * ((npc.oldPos.Length - k) / (float)npc.oldPos.Length);
                Rectangle frame = new Rectangle(0, 164 * (k / 60), 50, 62);

                spriteBatch.Draw(Main.npcTexture[npc.type], npc.oldPos[k] - Main.screenPosition, frame, color, 0, Vector2.Zero, npc.scale, effect, 1f);
            }
            return true;
        }
        public override void HitEffect(int hitDirection, double damage)
        {

            for (int num623 = 0; num623 < 5; num623++)
            {
                int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 4f;
            }
            if (npc.life <= 0)
            {
                for (int num623 = 0; num623 < 100; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 4f;
                }
                if (Main.expertMode && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.netUpdate = true;
                    Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 0f, 0f, mod.ProjectileType("SpiritSpawn"), 0, 0f, Main.myPlayer, 0f, 0f);
                }
                /*else
                {
                    if (!PrimordialSandsWorld.downedIndenwoodBark)
                    {
                        PrimordialSandsWorld.downedIndenwoodBark = true;
                    }
                }*/
            }
        }

        /*public override void NPCLoot()
        {
            if Main.rand.Next(7);
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Mask>());
            }

            if (!Main.expertMode)
            {
                int itemChoice = Main.rand.Next(4);
                if (itemChoice == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<LootDrop>());
                }
                else if (itemChoice == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<LootDrop>());
                }
                else if (itemChoice == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<LootDrop>());
                }
                else if (itemChoice == 3)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<LootDrop>());
                }
            }
        }*/
    }
}