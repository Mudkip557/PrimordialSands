using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.NPCs.Desert
{
    public class UmberHulk : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Umber Hulk");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = 3;
            aiType = -1;
            //animationType = 508;
            npc.damage = 17;
            npc.defense = 7;
            npc.lifeMax = 105;
            npc.width = 96;
            npc.height = 112;
            npc.knockBackResist = 0.35f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.DD2_OgreDeath;
            npc.value = Terraria.Item.buyPrice(0, 0, 2, 0);
        }
        public override void AI()
        {
            npc.knockBackResist = 0.4f * Main.knockBackMultiplier;
            npc.noGravity = false;
            Vector2 center2 = npc.Center;
            if (npc.ai[3] == -0.10101f)
            {
                npc.ai[3] = 0f;
                float num3 = npc.velocity.Length();
                num3 *= 2f;
                if (num3 > 10f)
                {
                    num3 = 10f;
                }
                npc.velocity.Normalize();
                npc.velocity *= num3;
                if (npc.velocity.X < 0f)
                {
                    npc.direction = -1;
                }
                if (npc.velocity.X > 0f)
                {
                    npc.direction = 1;
                }
                npc.spriteDirection = npc.direction;
            }
            int num37 = 60;
            bool flag5 = false;
            if (npc.ai[3] < (float)num37 && Main.LocalPlayer.ZoneDesert)
            {
                if (Main.rand.Next(1300) == 0)
                {
                    Main.PlaySound(SoundID.DD2_OgreAttack, npc.position);
                }
                if (Main.rand.Next(1400) == 0)
                {
                    Main.PlaySound(SoundID.DD2_OgreHurt, npc.position);
                }
                if (Main.rand.Next(1200) == 0)
                {
                    Main.PlaySound(SoundID.DD2_OgreRoar, npc.position);
                }
                npc.TargetClosest(true);
            }
            else if (npc.ai[2] <= 0f)
            {
                if (Main.dayTime && (double)(npc.position.Y / 16f) < Main.worldSurface && npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                }
                if (npc.velocity.X == 0f)
                {
                    if (npc.velocity.Y == 0f)
                    {
                        npc.ai[0] += 1f;
                        if (npc.ai[0] >= 2f)
                        {
                            npc.direction *= -1;
                            npc.spriteDirection = npc.direction;
                            npc.ai[0] = 0f;
                        }
                    }
                }
                else
                {
                    npc.ai[0] = 0f;
                }
                if (npc.direction == 0)
                {
                    npc.direction = 1;
                }
            }
            if (npc.ai[2] == 0f)
            {
                npc.damage = npc.defDamage;
                float num75 = 1f;
                num75 *= 1f + (1f - npc.scale);
                if (npc.velocity.X < -num75 || npc.velocity.X > num75)
                {
                    if (npc.velocity.Y == 0f)
                    {
                        npc.velocity *= 0.8f;
                    }
                }
                else if (npc.velocity.X < num75 && npc.direction == 1)
                {
                    npc.velocity.X = npc.velocity.X + 0.07f;
                    if (npc.velocity.X > num75)
                    {
                        npc.velocity.X = num75;
                    }
                }
                else if (npc.velocity.X > -num75 && npc.direction == -1)
                {
                    npc.velocity.X = npc.velocity.X - 0.07f;
                    if (npc.velocity.X < -num75)
                    {
                        npc.velocity.X = -num75;
                    }
                }
                if (npc.velocity.Y == 0f && (!Main.dayTime || (double)npc.position.Y > Main.worldSurface * 16.0) && !Main.player[npc.target].dead)
                {
                    Vector2 vector13 = npc.Center - Main.player[npc.target].Center;
                    int num76 = 50;
                    if (vector13.Length() < (float)num76 && Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
                    {
                        npc.velocity.X = npc.velocity.X * 0.7f;
                        npc.ai[2] = 1f;
                    }
                }
            }
            else
            {
                npc.damage = (int)((double)npc.defDamage * 1.5);
                npc.ai[3] = 1f;
                npc.velocity.X = npc.velocity.X * 0.9f;
                if ((double)Math.Abs(npc.velocity.X) < 0.1)
                {
                    npc.velocity.X = 0f;
                }
                npc.ai[2] += 1f;
                if (npc.ai[2] >= 20f || npc.velocity.Y != 0f || (Main.dayTime && (double)npc.position.Y < Main.worldSurface * 16.0))
                {
                    npc.ai[2] = 0f;
                }
            }

            float num58 = 1.5f;
            if (npc.velocity.X < -num58 || npc.velocity.X > num58)
            {
                if (npc.velocity.Y == 0f)
                {
                    npc.velocity *= 0.8f;
                }
            }
            else if (npc.velocity.X < num58 && npc.direction == 1)
            {
                npc.velocity.X = npc.velocity.X + 0.07f;
                if (npc.velocity.X > num58)
                {
                    npc.velocity.X = num58;
                }
            }
            else if (npc.velocity.X > -num58 && npc.direction == -1)
            {
                npc.velocity.X = npc.velocity.X - 0.07f;
                if (npc.velocity.X < -num58)
                {
                    npc.velocity.X = -num58;
                }
            }
        }

        public static void GetMeleeCollisionData(Rectangle victimHitbox, int enemyIndex, ref int specialHitSetter, ref float damageMultiplier, ref Rectangle npcRect)
        {
            NPC nPC = Main.npc[enemyIndex];
            if (nPC.ai[2] > 5f)
            {
                int num = 34;
                if (nPC.spriteDirection < 0)
                {
                    npcRect.X -= num;
                    npcRect.Width += num;
                }
                else
                {
                    npcRect.Width += num;
                }
                damageMultiplier *= 1.25f;
                return;
            }
        }
    }
}