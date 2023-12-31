﻿using System.Collections.Immutable;

namespace YiJingFramework.Nongli.Lunar;

internal static class LunarTables
{
    internal const int STARTING_NIAN = 1901;
    internal const byte STARTING_NIAN_GANZHI = 38;

    internal static ImmutableArray<int> NianStartDayNumberTable { get; }

    internal static ImmutableArray<byte> RunyueIndexTable { get; }

    internal static ImmutableArray<short> RiCountOfYueTable { get; }


    static LunarTables()
    {
        {
            // LunarConstantProperties
        }

        {
            // NianStartDayNumberTable
            var builder = ImmutableArray.CreateBuilder<int>(299);
            builder.Add(694009); // 1901 2-19
            builder.Add(694363); // 1902 2-8
            builder.Add(694718); // 1903 1-29
            builder.Add(695101); // 1904 2-16
            builder.Add(695455); // 1905 2-4
            builder.Add(695810); // 1906 1-25
            builder.Add(696194); // 1907 2-13
            builder.Add(696548); // 1908 2-2
            builder.Add(696903); // 1909 1-22
            builder.Add(697287); // 1910 2-10
            builder.Add(697641); // 1911 1-30
            builder.Add(698025); // 1912 2-18
            builder.Add(698379); // 1913 2-6
            builder.Add(698733); // 1914 1-26
            builder.Add(699117); // 1915 2-14
            builder.Add(699471); // 1916 2-3
            builder.Add(699826); // 1917 1-23
            builder.Add(700210); // 1918 2-11
            builder.Add(700565); // 1919 2-1
            builder.Add(700949); // 1920 2-20
            builder.Add(701303); // 1921 2-8
            builder.Add(701657); // 1922 1-28
            builder.Add(702041); // 1923 2-16
            builder.Add(702395); // 1924 2-5
            builder.Add(702749); // 1925 1-24
            builder.Add(703134); // 1926 2-13
            builder.Add(703488); // 1927 2-2
            builder.Add(703843); // 1928 1-23
            builder.Add(704227); // 1929 2-10
            builder.Add(704581); // 1930 1-30
            builder.Add(704964); // 1931 2-17
            builder.Add(705318); // 1932 2-6
            builder.Add(705673); // 1933 1-26
            builder.Add(706057); // 1934 2-14
            builder.Add(706412); // 1935 2-4
            builder.Add(706766); // 1936 1-24
            builder.Add(707150); // 1937 2-11
            builder.Add(707504); // 1938 1-31
            builder.Add(707888); // 1939 2-19
            builder.Add(708242); // 1940 2-8
            builder.Add(708596); // 1941 1-27
            builder.Add(708980); // 1942 2-15
            builder.Add(709335); // 1943 2-5
            builder.Add(709689); // 1944 1-25
            builder.Add(710074); // 1945 2-13
            builder.Add(710428); // 1946 2-2
            builder.Add(710782); // 1947 1-22
            builder.Add(711166); // 1948 2-10
            builder.Add(711520); // 1949 1-29
            builder.Add(711904); // 1950 2-17
            builder.Add(712258); // 1951 2-6
            builder.Add(712613); // 1952 1-27
            builder.Add(712997); // 1953 2-14
            builder.Add(713351); // 1954 2-3
            builder.Add(713706); // 1955 1-24
            builder.Add(714090); // 1956 2-12
            builder.Add(714444); // 1957 1-31
            builder.Add(714827); // 1958 2-18
            builder.Add(715182); // 1959 2-8
            builder.Add(715536); // 1960 1-28
            builder.Add(715920); // 1961 2-15
            builder.Add(716275); // 1962 2-5
            builder.Add(716629); // 1963 1-25
            builder.Add(717013); // 1964 2-13
            builder.Add(717368); // 1965 2-2
            builder.Add(717721); // 1966 1-21
            builder.Add(718105); // 1967 2-9
            builder.Add(718460); // 1968 1-30
            builder.Add(718844); // 1969 2-17
            builder.Add(719198); // 1970 2-6
            builder.Add(719553); // 1971 1-27
            builder.Add(719937); // 1972 2-15
            builder.Add(720291); // 1973 2-3
            builder.Add(720645); // 1974 1-23
            builder.Add(721029); // 1975 2-11
            builder.Add(721383); // 1976 1-31
            builder.Add(721767); // 1977 2-18
            builder.Add(722121); // 1978 2-7
            builder.Add(722476); // 1979 1-28
            builder.Add(722860); // 1980 2-16
            builder.Add(723215); // 1981 2-5
            builder.Add(723569); // 1982 1-25
            builder.Add(723953); // 1983 2-13
            builder.Add(724307); // 1984 2-2
            builder.Add(724691); // 1985 2-20
            builder.Add(725045); // 1986 2-9
            builder.Add(725399); // 1987 1-29
            builder.Add(725783); // 1988 2-17
            builder.Add(726138); // 1989 2-6
            builder.Add(726493); // 1990 1-27
            builder.Add(726877); // 1991 2-15
            builder.Add(727231); // 1992 2-4
            builder.Add(727585); // 1993 1-23
            builder.Add(727968); // 1994 2-10
            builder.Add(728323); // 1995 1-31
            builder.Add(728707); // 1996 2-19
            builder.Add(729061); // 1997 2-7
            builder.Add(729416); // 1998 1-28
            builder.Add(729800); // 1999 2-16
            builder.Add(730154); // 2000 2-5
            builder.Add(730508); // 2001 1-24
            builder.Add(730892); // 2002 2-12
            builder.Add(731246); // 2003 2-1
            builder.Add(731601); // 2004 1-22
            builder.Add(731985); // 2005 2-9
            builder.Add(732339); // 2006 1-29
            builder.Add(732724); // 2007 2-18
            builder.Add(733078); // 2008 2-7
            builder.Add(733432); // 2009 1-26
            builder.Add(733816); // 2010 2-14
            builder.Add(734170); // 2011 2-3
            builder.Add(734524); // 2012 1-23
            builder.Add(734908); // 2013 2-10
            builder.Add(735263); // 2014 1-31
            builder.Add(735647); // 2015 2-19
            builder.Add(736001); // 2016 2-8
            builder.Add(736356); // 2017 1-28
            builder.Add(736740); // 2018 2-16
            builder.Add(737094); // 2019 2-5
            builder.Add(737448); // 2020 1-25
            builder.Add(737832); // 2021 2-12
            builder.Add(738186); // 2022 2-1
            builder.Add(738541); // 2023 1-22
            builder.Add(738925); // 2024 2-10
            builder.Add(739279); // 2025 1-29
            builder.Add(739663); // 2026 2-17
            builder.Add(740017); // 2027 2-6
            builder.Add(740371); // 2028 1-26
            builder.Add(740755); // 2029 2-13
            builder.Add(741110); // 2030 2-3
            builder.Add(741464); // 2031 1-23
            builder.Add(741848); // 2032 2-11
            builder.Add(742203); // 2033 1-31
            builder.Add(742587); // 2034 2-19
            builder.Add(742941); // 2035 2-8
            builder.Add(743295); // 2036 1-28
            builder.Add(743679); // 2037 2-15
            builder.Add(744033); // 2038 2-4
            builder.Add(744387); // 2039 1-24
            builder.Add(744771); // 2040 2-12
            builder.Add(745126); // 2041 2-1
            builder.Add(745481); // 2042 1-22
            builder.Add(745865); // 2043 2-10
            builder.Add(746219); // 2044 1-30
            builder.Add(746603); // 2045 2-17
            builder.Add(746957); // 2046 2-6
            builder.Add(747311); // 2047 1-26
            builder.Add(747695); // 2048 2-14
            builder.Add(748049); // 2049 2-2
            builder.Add(748404); // 2050 1-23
            builder.Add(748788); // 2051 2-11
            builder.Add(749143); // 2052 2-1
            builder.Add(749527); // 2053 2-19
            builder.Add(749881); // 2054 2-8
            builder.Add(750235); // 2055 1-28
            builder.Add(750618); // 2056 2-15
            builder.Add(750973); // 2057 2-4
            builder.Add(751327); // 2058 1-24
            builder.Add(751711); // 2059 2-12
            builder.Add(752066); // 2060 2-2
            builder.Add(752420); // 2061 1-21
            builder.Add(752804); // 2062 2-9
            builder.Add(753158); // 2063 1-29
            builder.Add(753542); // 2064 2-17
            builder.Add(753896); // 2065 2-5
            builder.Add(754251); // 2066 1-26
            builder.Add(754635); // 2067 2-14
            builder.Add(754989); // 2068 2-3
            builder.Add(755344); // 2069 1-23
            builder.Add(755728); // 2070 2-11
            builder.Add(756082); // 2071 1-31
            builder.Add(756466); // 2072 2-19
            builder.Add(756820); // 2073 2-7
            builder.Add(757174); // 2074 1-27
            builder.Add(757558); // 2075 2-15
            builder.Add(757913); // 2076 2-5
            builder.Add(758267); // 2077 1-24
            builder.Add(758651); // 2078 2-12
            builder.Add(759006); // 2079 2-2
            builder.Add(759360); // 2080 1-22
            builder.Add(759744); // 2081 2-9
            builder.Add(760098); // 2082 1-29
            builder.Add(760482); // 2083 2-17
            builder.Add(760836); // 2084 2-6
            builder.Add(761191); // 2085 1-26
            builder.Add(761575); // 2086 2-14
            builder.Add(761929); // 2087 2-3
            builder.Add(762284); // 2088 1-24
            builder.Add(762667); // 2089 2-10
            builder.Add(763021); // 2090 1-30
            builder.Add(763405); // 2091 2-18
            builder.Add(763759); // 2092 2-7
            builder.Add(764114); // 2093 1-27
            builder.Add(764498); // 2094 2-15
            builder.Add(764853); // 2095 2-5
            builder.Add(765207); // 2096 1-25
            builder.Add(765591); // 2097 2-12
            builder.Add(765945); // 2098 2-1
            builder.Add(766299); // 2099 1-21
            builder.Add(766683); // 2100 2-9
            builder.Add(767037); // 2101 1-29
            builder.Add(767421); // 2102 2-17
            builder.Add(767776); // 2103 2-7
            builder.Add(768131); // 2104 1-28
            builder.Add(768515); // 2105 2-15
            builder.Add(768869); // 2106 2-4
            builder.Add(769223); // 2107 1-24
            builder.Add(769607); // 2108 2-12
            builder.Add(769961); // 2109 1-31
            builder.Add(770345); // 2110 2-19
            builder.Add(770699); // 2111 2-8
            builder.Add(771054); // 2112 1-29
            builder.Add(771438); // 2113 2-16
            builder.Add(771793); // 2114 2-6
            builder.Add(772147); // 2115 1-26
            builder.Add(772531); // 2116 2-14
            builder.Add(772885); // 2117 2-2
            builder.Add(773239); // 2118 1-22
            builder.Add(773623); // 2119 2-10
            builder.Add(773977); // 2120 1-30
            builder.Add(774361); // 2121 2-17
            builder.Add(774716); // 2122 2-7
            builder.Add(775070); // 2123 1-27
            builder.Add(775454); // 2124 2-15
            builder.Add(775808); // 2125 2-3
            builder.Add(776162); // 2126 1-23
            builder.Add(776546); // 2127 2-11
            builder.Add(776901); // 2128 2-1
            builder.Add(777285); // 2129 2-19
            builder.Add(777639); // 2130 2-8
            builder.Add(777994); // 2131 1-29
            builder.Add(778378); // 2132 2-17
            builder.Add(778732); // 2133 2-5
            builder.Add(779086); // 2134 1-25
            builder.Add(779470); // 2135 2-13
            builder.Add(779824); // 2136 2-2
            builder.Add(780179); // 2137 1-22
            builder.Add(780563); // 2138 2-10
            builder.Add(780917); // 2139 1-30
            builder.Add(781301); // 2140 2-18
            builder.Add(781656); // 2141 2-7
            builder.Add(782010); // 2142 1-27
            builder.Add(782394); // 2143 2-15
            builder.Add(782748); // 2144 2-4
            builder.Add(783102); // 2145 1-23
            builder.Add(783486); // 2146 2-11
            builder.Add(783841); // 2147 2-1
            builder.Add(784225); // 2148 2-20
            builder.Add(784579); // 2149 2-8
            builder.Add(784934); // 2150 1-29
            builder.Add(785317); // 2151 2-16
            builder.Add(785671); // 2152 2-5
            builder.Add(786026); // 2153 1-25
            builder.Add(786409); // 2154 2-12
            builder.Add(786764); // 2155 2-2
            builder.Add(787119); // 2156 1-23
            builder.Add(787503); // 2157 2-10
            builder.Add(787857); // 2158 1-30
            builder.Add(788241); // 2159 2-18
            builder.Add(788595); // 2160 2-7
            builder.Add(788949); // 2161 1-26
            builder.Add(789333); // 2162 2-14
            builder.Add(789687); // 2163 2-3
            builder.Add(790042); // 2164 1-24
            builder.Add(790426); // 2165 2-11
            builder.Add(790781); // 2166 2-1
            builder.Add(791165); // 2167 2-20
            builder.Add(791519); // 2168 2-9
            builder.Add(791873); // 2169 1-28
            builder.Add(792257); // 2170 2-16
            builder.Add(792611); // 2171 2-5
            builder.Add(792965); // 2172 1-25
            builder.Add(793349); // 2173 2-12
            builder.Add(793704); // 2174 2-2
            builder.Add(794059); // 2175 1-23
            builder.Add(794443); // 2176 2-11
            builder.Add(794797); // 2177 1-30
            builder.Add(795181); // 2178 2-18
            builder.Add(795535); // 2179 2-7
            builder.Add(795889); // 2180 1-27
            builder.Add(796273); // 2181 2-14
            builder.Add(796627); // 2182 2-3
            builder.Add(796982); // 2183 1-24
            builder.Add(797366); // 2184 2-12
            builder.Add(797720); // 2185 1-31
            builder.Add(798075); // 2186 1-21
            builder.Add(798458); // 2187 2-8
            builder.Add(798812); // 2188 1-28
            builder.Add(799196); // 2189 2-15
            builder.Add(799551); // 2190 2-5
            builder.Add(799905); // 2191 1-25
            builder.Add(800289); // 2192 2-13
            builder.Add(800644); // 2193 2-2
            builder.Add(800998); // 2194 1-22
            builder.Add(801382); // 2195 2-10
            builder.Add(801736); // 2196 1-30
            builder.Add(802120); // 2197 2-17
            builder.Add(802474); // 2198 2-6
            builder.Add(802829); // 2199 1-27
            NianStartDayNumberTable = builder.MoveToImmutable();
        }

        {
            // RunyueIndexTable
            var builder = ImmutableArray.CreateBuilder<byte>(299);
            builder.Add(0); // 1901
            builder.Add(0); // 1902
            builder.Add(5); // 1903
            builder.Add(0); // 1904
            builder.Add(0); // 1905
            builder.Add(4); // 1906
            builder.Add(0); // 1907
            builder.Add(0); // 1908
            builder.Add(2); // 1909
            builder.Add(0); // 1910
            builder.Add(6); // 1911
            builder.Add(0); // 1912
            builder.Add(0); // 1913
            builder.Add(5); // 1914
            builder.Add(0); // 1915
            builder.Add(0); // 1916
            builder.Add(2); // 1917
            builder.Add(0); // 1918
            builder.Add(7); // 1919
            builder.Add(0); // 1920
            builder.Add(0); // 1921
            builder.Add(5); // 1922
            builder.Add(0); // 1923
            builder.Add(0); // 1924
            builder.Add(4); // 1925
            builder.Add(0); // 1926
            builder.Add(0); // 1927
            builder.Add(2); // 1928
            builder.Add(0); // 1929
            builder.Add(6); // 1930
            builder.Add(0); // 1931
            builder.Add(0); // 1932
            builder.Add(5); // 1933
            builder.Add(0); // 1934
            builder.Add(0); // 1935
            builder.Add(3); // 1936
            builder.Add(0); // 1937
            builder.Add(7); // 1938
            builder.Add(0); // 1939
            builder.Add(0); // 1940
            builder.Add(6); // 1941
            builder.Add(0); // 1942
            builder.Add(0); // 1943
            builder.Add(4); // 1944
            builder.Add(0); // 1945
            builder.Add(0); // 1946
            builder.Add(2); // 1947
            builder.Add(0); // 1948
            builder.Add(7); // 1949
            builder.Add(0); // 1950
            builder.Add(0); // 1951
            builder.Add(5); // 1952
            builder.Add(0); // 1953
            builder.Add(0); // 1954
            builder.Add(3); // 1955
            builder.Add(0); // 1956
            builder.Add(8); // 1957
            builder.Add(0); // 1958
            builder.Add(0); // 1959
            builder.Add(6); // 1960
            builder.Add(0); // 1961
            builder.Add(0); // 1962
            builder.Add(4); // 1963
            builder.Add(0); // 1964
            builder.Add(0); // 1965
            builder.Add(3); // 1966
            builder.Add(0); // 1967
            builder.Add(7); // 1968
            builder.Add(0); // 1969
            builder.Add(0); // 1970
            builder.Add(5); // 1971
            builder.Add(0); // 1972
            builder.Add(0); // 1973
            builder.Add(4); // 1974
            builder.Add(0); // 1975
            builder.Add(8); // 1976
            builder.Add(0); // 1977
            builder.Add(0); // 1978
            builder.Add(6); // 1979
            builder.Add(0); // 1980
            builder.Add(0); // 1981
            builder.Add(4); // 1982
            builder.Add(0); // 1983
            builder.Add(10); // 1984
            builder.Add(0); // 1985
            builder.Add(0); // 1986
            builder.Add(6); // 1987
            builder.Add(0); // 1988
            builder.Add(0); // 1989
            builder.Add(5); // 1990
            builder.Add(0); // 1991
            builder.Add(0); // 1992
            builder.Add(3); // 1993
            builder.Add(0); // 1994
            builder.Add(8); // 1995
            builder.Add(0); // 1996
            builder.Add(0); // 1997
            builder.Add(5); // 1998
            builder.Add(0); // 1999
            builder.Add(0); // 2000
            builder.Add(4); // 2001
            builder.Add(0); // 2002
            builder.Add(0); // 2003
            builder.Add(2); // 2004
            builder.Add(0); // 2005
            builder.Add(7); // 2006
            builder.Add(0); // 2007
            builder.Add(0); // 2008
            builder.Add(5); // 2009
            builder.Add(0); // 2010
            builder.Add(0); // 2011
            builder.Add(4); // 2012
            builder.Add(0); // 2013
            builder.Add(9); // 2014
            builder.Add(0); // 2015
            builder.Add(0); // 2016
            builder.Add(6); // 2017
            builder.Add(0); // 2018
            builder.Add(0); // 2019
            builder.Add(4); // 2020
            builder.Add(0); // 2021
            builder.Add(0); // 2022
            builder.Add(2); // 2023
            builder.Add(0); // 2024
            builder.Add(6); // 2025
            builder.Add(0); // 2026
            builder.Add(0); // 2027
            builder.Add(5); // 2028
            builder.Add(0); // 2029
            builder.Add(0); // 2030
            builder.Add(3); // 2031
            builder.Add(0); // 2032
            builder.Add(11); // 2033
            builder.Add(0); // 2034
            builder.Add(0); // 2035
            builder.Add(6); // 2036
            builder.Add(0); // 2037
            builder.Add(0); // 2038
            builder.Add(5); // 2039
            builder.Add(0); // 2040
            builder.Add(0); // 2041
            builder.Add(2); // 2042
            builder.Add(0); // 2043
            builder.Add(7); // 2044
            builder.Add(0); // 2045
            builder.Add(0); // 2046
            builder.Add(5); // 2047
            builder.Add(0); // 2048
            builder.Add(0); // 2049
            builder.Add(3); // 2050
            builder.Add(0); // 2051
            builder.Add(8); // 2052
            builder.Add(0); // 2053
            builder.Add(0); // 2054
            builder.Add(6); // 2055
            builder.Add(0); // 2056
            builder.Add(0); // 2057
            builder.Add(4); // 2058
            builder.Add(0); // 2059
            builder.Add(0); // 2060
            builder.Add(3); // 2061
            builder.Add(0); // 2062
            builder.Add(7); // 2063
            builder.Add(0); // 2064
            builder.Add(0); // 2065
            builder.Add(5); // 2066
            builder.Add(0); // 2067
            builder.Add(0); // 2068
            builder.Add(4); // 2069
            builder.Add(0); // 2070
            builder.Add(8); // 2071
            builder.Add(0); // 2072
            builder.Add(0); // 2073
            builder.Add(6); // 2074
            builder.Add(0); // 2075
            builder.Add(0); // 2076
            builder.Add(4); // 2077
            builder.Add(0); // 2078
            builder.Add(0); // 2079
            builder.Add(3); // 2080
            builder.Add(0); // 2081
            builder.Add(7); // 2082
            builder.Add(0); // 2083
            builder.Add(0); // 2084
            builder.Add(5); // 2085
            builder.Add(0); // 2086
            builder.Add(0); // 2087
            builder.Add(4); // 2088
            builder.Add(0); // 2089
            builder.Add(8); // 2090
            builder.Add(0); // 2091
            builder.Add(0); // 2092
            builder.Add(6); // 2093
            builder.Add(0); // 2094
            builder.Add(0); // 2095
            builder.Add(4); // 2096
            builder.Add(0); // 2097
            builder.Add(0); // 2098
            builder.Add(2); // 2099
            builder.Add(0); // 2100
            builder.Add(7); // 2101
            builder.Add(0); // 2102
            builder.Add(0); // 2103
            builder.Add(5); // 2104
            builder.Add(0); // 2105
            builder.Add(0); // 2106
            builder.Add(4); // 2107
            builder.Add(0); // 2108
            builder.Add(9); // 2109
            builder.Add(0); // 2110
            builder.Add(0); // 2111
            builder.Add(6); // 2112
            builder.Add(0); // 2113
            builder.Add(0); // 2114
            builder.Add(4); // 2115
            builder.Add(0); // 2116
            builder.Add(0); // 2117
            builder.Add(3); // 2118
            builder.Add(0); // 2119
            builder.Add(7); // 2120
            builder.Add(0); // 2121
            builder.Add(0); // 2122
            builder.Add(5); // 2123
            builder.Add(0); // 2124
            builder.Add(0); // 2125
            builder.Add(4); // 2126
            builder.Add(0); // 2127
            builder.Add(11); // 2128
            builder.Add(0); // 2129
            builder.Add(0); // 2130
            builder.Add(6); // 2131
            builder.Add(0); // 2132
            builder.Add(0); // 2133
            builder.Add(5); // 2134
            builder.Add(0); // 2135
            builder.Add(0); // 2136
            builder.Add(2); // 2137
            builder.Add(0); // 2138
            builder.Add(7); // 2139
            builder.Add(0); // 2140
            builder.Add(0); // 2141
            builder.Add(5); // 2142
            builder.Add(0); // 2143
            builder.Add(0); // 2144
            builder.Add(4); // 2145
            builder.Add(0); // 2146
            builder.Add(11); // 2147
            builder.Add(0); // 2148
            builder.Add(0); // 2149
            builder.Add(6); // 2150
            builder.Add(0); // 2151
            builder.Add(0); // 2152
            builder.Add(5); // 2153
            builder.Add(0); // 2154
            builder.Add(0); // 2155
            builder.Add(3); // 2156
            builder.Add(0); // 2157
            builder.Add(7); // 2158
            builder.Add(0); // 2159
            builder.Add(0); // 2160
            builder.Add(6); // 2161
            builder.Add(0); // 2162
            builder.Add(0); // 2163
            builder.Add(4); // 2164
            builder.Add(0); // 2165
            builder.Add(10); // 2166
            builder.Add(0); // 2167
            builder.Add(0); // 2168
            builder.Add(6); // 2169
            builder.Add(0); // 2170
            builder.Add(0); // 2171
            builder.Add(5); // 2172
            builder.Add(0); // 2173
            builder.Add(0); // 2174
            builder.Add(3); // 2175
            builder.Add(0); // 2176
            builder.Add(7); // 2177
            builder.Add(0); // 2178
            builder.Add(0); // 2179
            builder.Add(6); // 2180
            builder.Add(0); // 2181
            builder.Add(0); // 2182
            builder.Add(4); // 2183
            builder.Add(0); // 2184
            builder.Add(0); // 2185
            builder.Add(2); // 2186
            builder.Add(0); // 2187
            builder.Add(6); // 2188
            builder.Add(0); // 2189
            builder.Add(0); // 2190
            builder.Add(5); // 2191
            builder.Add(0); // 2192
            builder.Add(0); // 2193
            builder.Add(3); // 2194
            builder.Add(0); // 2195
            builder.Add(7); // 2196
            builder.Add(0); // 2197
            builder.Add(0); // 2198
            builder.Add(6); // 2199
            RunyueIndexTable = builder.MoveToImmutable();

        }

        {
            // RiCountOfYueTable
            var builder = ImmutableArray.CreateBuilder<short>(299);
            builder.Add(0b0100101011100); // 1901 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1010010101110); // 1902 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0101001001101); // 1903 C29 C30 C29 C30 C29 L29 C30 C29 C29 C30 C30 C29 C30 
            builder.Add(0b1101001001100); // 1904 C30 C30 C29 C30 C29 C29 C30 C29 C29 C30 C30 C29 
            builder.Add(0b1101100101010); // 1905 C30 C30 C29 C30 C30 C29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0110101010101); // 1906 C29 C30 C30 C29 L30 C29 C30 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0101011010100); // 1907 C29 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1001101011010); // 1908 C30 C29 C29 C30 C30 C29 C30 C29 C30 C30 C29 C30 
            builder.Add(0b0100101011101); // 1909 C29 C30 L29 C29 C30 C29 C30 C29 C30 C30 C30 C29 C30 
            builder.Add(0b0100101011100); // 1910 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1010010011011); // 1911 C30 C29 C30 C29 C29 C30 L29 C29 C30 C30 C29 C30 C30 
            builder.Add(0b1010010011010); // 1912 C30 C29 C30 C29 C29 C30 C29 C29 C30 C30 C29 C30 
            builder.Add(0b1101001001010); // 1913 C30 C30 C29 C30 C29 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b1101010100101); // 1914 C30 C30 C29 C30 C29 L30 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b1011010101000); // 1915 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 C29 C29 
            builder.Add(0b1101011010100); // 1916 C30 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1001011011010); // 1917 C30 C29 L29 C30 C29 C30 C30 C29 C30 C30 C29 C30 C29 
            builder.Add(0b1001010110110); // 1918 C30 C29 C29 C30 C29 C30 C29 C30 C30 C29 C30 C30 
            builder.Add(0b0100100110111); // 1919 C29 C30 C29 C29 C30 C29 C29 L30 C30 C29 C30 C30 C30 
            builder.Add(0b0100100101110); // 1920 C29 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 C30 
            builder.Add(0b1010010010110); // 1921 C30 C29 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 
            builder.Add(0b1011001001011); // 1922 C30 C29 C30 C30 C29 L29 C30 C29 C29 C30 C29 C30 C30 
            builder.Add(0b0110101001010); // 1923 C29 C30 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b0110110101000); // 1924 C29 C30 C30 C29 C30 C30 C29 C30 C29 C30 C29 C29 
            builder.Add(0b1010110110101); // 1925 C30 C29 C30 C29 L30 C30 C29 C30 C30 C29 C30 C29 C30 
            builder.Add(0b0010101101100); // 1926 C29 C29 C30 C29 C30 C29 C30 C30 C29 C30 C30 C29 
            builder.Add(0b1001010101110); // 1927 C30 C29 C29 C30 C29 C30 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0100100101111); // 1928 C29 C30 L29 C29 C30 C29 C29 C30 C29 C30 C30 C30 C30 
            builder.Add(0b0100100101110); // 1929 C29 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0110010010110); // 1930 C29 C30 C30 C29 C29 C30 L29 C29 C30 C29 C30 C30 C29 
            builder.Add(0b1101010010100); // 1931 C30 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 C29 
            builder.Add(0b1110101001010); // 1932 C30 C30 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b0110110101001); // 1933 C29 C30 C30 C29 C30 L30 C29 C30 C29 C30 C29 C29 C30 
            builder.Add(0b0101101011010); // 1934 C29 C30 C29 C30 C30 C29 C30 C29 C30 C30 C29 C30 
            builder.Add(0b0010101101100); // 1935 C29 C29 C30 C29 C30 C29 C30 C30 C29 C30 C30 C29 
            builder.Add(0b1001001101110); // 1936 C30 C29 C29 L30 C29 C29 C30 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1001001011100); // 1937 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1100100101101); // 1938 C30 C30 C29 C29 C30 C29 C29 L30 C29 C30 C30 C29 C30 
            builder.Add(0b1100100101010); // 1939 C30 C30 C29 C29 C30 C29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b1101010010100); // 1940 C30 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 C29 
            builder.Add(0b1101101001010); // 1941 C30 C30 C29 C30 C30 C29 L30 C29 C29 C30 C29 C30 C29 
            builder.Add(0b1011010101010); // 1942 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0101011010100); // 1943 C29 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010101011011); // 1944 C30 C29 C30 C29 L30 C29 C30 C29 C30 C30 C29 C30 C30 
            builder.Add(0b0010010111010); // 1945 C29 C29 C30 C29 C29 C30 C29 C30 C30 C30 C29 C30 
            builder.Add(0b1001001011010); // 1946 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 C29 C30 
            builder.Add(0b1100100101011); // 1947 C30 C30 L29 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 
            builder.Add(0b1010100101010); // 1948 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b1011010010101); // 1949 C30 C29 C30 C30 C29 C30 C29 L29 C30 C29 C30 C29 C30 
            builder.Add(0b0110110010100); // 1950 C29 C30 C30 C29 C30 C30 C29 C29 C30 C29 C30 C29 
            builder.Add(0b1011010101010); // 1951 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0101010110101); // 1952 C29 C30 C29 C30 C29 L30 C29 C30 C30 C29 C30 C29 C30 
            builder.Add(0b0100110110100); // 1953 C29 C30 C29 C29 C30 C30 C29 C30 C30 C29 C30 C29 
            builder.Add(0b1010010110110); // 1954 C30 C29 C30 C29 C29 C30 C29 C30 C30 C29 C30 C30 
            builder.Add(0b0101001010111); // 1955 C29 C30 C29 L30 C29 C29 C30 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0101001010110); // 1956 C29 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 
            builder.Add(0b1010100101010); // 1957 C30 C29 C30 C29 C30 C29 C29 C30 L29 C30 C29 C30 C29 
            builder.Add(0b1110100101010); // 1958 C30 C30 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0110101010100); // 1959 C29 C30 C30 C29 C30 C29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010110101010); // 1960 C30 C29 C30 C29 C30 C30 L29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010101101010); // 1961 C30 C29 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 
            builder.Add(0b0100101101100); // 1962 C29 C30 C29 C29 C30 C29 C30 C30 C29 C30 C30 C29 
            builder.Add(0b1010010101110); // 1963 C30 C29 C30 C29 L29 C30 C29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1010010101110); // 1964 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0101001001100); // 1965 C29 C30 C29 C30 C29 C29 C30 C29 C29 C30 C30 C29 
            builder.Add(0b1110100100110); // 1966 C30 C30 C30 L29 C30 C29 C29 C30 C29 C29 C30 C30 C29 
            builder.Add(0b1101100101010); // 1967 C30 C30 C29 C30 C30 C29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0101101010101); // 1968 C29 C30 C29 C30 C30 C29 C30 L29 C30 C29 C30 C29 C30 
            builder.Add(0b0101011010100); // 1969 C29 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1001011011010); // 1970 C30 C29 C29 C30 C29 C30 C30 C29 C30 C30 C29 C30 
            builder.Add(0b0100101011101); // 1971 C29 C30 C29 C29 C30 L29 C30 C29 C30 C30 C30 C29 C30 
            builder.Add(0b0100101011010); // 1972 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 C29 C30 
            builder.Add(0b1010010011010); // 1973 C30 C29 C30 C29 C29 C30 C29 C29 C30 C30 C29 C30 
            builder.Add(0b1101001001101); // 1974 C30 C30 C29 C30 L29 C29 C30 C29 C29 C30 C30 C29 C30 
            builder.Add(0b1101001001010); // 1975 C30 C30 C29 C30 C29 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b1101010100101); // 1976 C30 C30 C29 C30 C29 C30 C29 C30 L29 C29 C30 C29 C30 
            builder.Add(0b1011010101000); // 1977 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 C29 C29 
            builder.Add(0b1011011010100); // 1978 C30 C29 C30 C30 C29 C30 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1001011011010); // 1979 C30 C29 C29 C30 C29 C30 L30 C29 C30 C30 C29 C30 C29 
            builder.Add(0b1001010110110); // 1980 C30 C29 C29 C30 C29 C30 C29 C30 C30 C29 C30 C30 
            builder.Add(0b0100100110110); // 1981 C29 C30 C29 C29 C30 C29 C29 C30 C30 C29 C30 C30 
            builder.Add(0b1010010010111); // 1982 C30 C29 C30 C29 L29 C30 C29 C29 C30 C29 C30 C30 C30 
            builder.Add(0b1010010010110); // 1983 C30 C29 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 
            builder.Add(0b1011001001011); // 1984 C30 C29 C30 C30 C29 C29 C30 C29 C29 C30 L29 C30 C30 
            builder.Add(0b0110101001010); // 1985 C29 C30 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b0110110101000); // 1986 C29 C30 C30 C29 C30 C30 C29 C30 C29 C30 C29 C29 
            builder.Add(0b1010110110100); // 1987 C30 C29 C30 C29 C30 C30 L29 C30 C30 C29 C30 C29 C29 
            builder.Add(0b1010101101100); // 1988 C30 C29 C30 C29 C30 C29 C30 C30 C29 C30 C30 C29 
            builder.Add(0b1001010101110); // 1989 C30 C29 C29 C30 C29 C30 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0100100101111); // 1990 C29 C30 C29 C29 C30 L29 C29 C30 C29 C30 C30 C30 C30 
            builder.Add(0b0100100101110); // 1991 C29 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0110010010110); // 1992 C29 C30 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 
            builder.Add(0b0110101001010); // 1993 C29 C30 C30 L29 C30 C29 C30 C29 C29 C30 C29 C30 C29 
            builder.Add(0b1110101001010); // 1994 C30 C30 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b0110101100101); // 1995 C29 C30 C30 C29 C30 C29 C30 C30 L29 C29 C30 C29 C30 
            builder.Add(0b0101101011000); // 1996 C29 C30 C29 C30 C30 C29 C30 C29 C30 C30 C29 C29 
            builder.Add(0b1010101101100); // 1997 C30 C29 C30 C29 C30 C29 C30 C30 C29 C30 C30 C29 
            builder.Add(0b1001001101101); // 1998 C30 C29 C29 C30 C29 L29 C30 C30 C29 C30 C30 C29 C30 
            builder.Add(0b1001001011100); // 1999 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1100100101100); // 2000 C30 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 C29 
            builder.Add(0b1101010010101); // 2001 C30 C30 C29 C30 L29 C30 C29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b1101010010100); // 2002 C30 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 C29 
            builder.Add(0b1101101001010); // 2003 C30 C30 C29 C30 C30 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b0101101010101); // 2004 C29 C30 L29 C30 C30 C29 C30 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0101011010100); // 2005 C29 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010101011011); // 2006 C30 C29 C30 C29 C30 C29 C30 L29 C30 C30 C29 C30 C30 
            builder.Add(0b0010010111010); // 2007 C29 C29 C30 C29 C29 C30 C29 C30 C30 C30 C29 C30 
            builder.Add(0b1001001011010); // 2008 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 C29 C30 
            builder.Add(0b1100100101011); // 2009 C30 C30 C29 C29 C30 L29 C29 C30 C29 C30 C29 C30 C30 
            builder.Add(0b1010100101010); // 2010 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b1011010010100); // 2011 C30 C29 C30 C30 C29 C30 C29 C29 C30 C29 C30 C29 
            builder.Add(0b1011010101010); // 2012 C30 C29 C30 C30 L29 C30 C29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010110101010); // 2013 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0101010110101); // 2014 C29 C30 C29 C30 C29 C30 C29 C30 C30 L29 C30 C29 C30 
            builder.Add(0b0100101110100); // 2015 C29 C30 C29 C29 C30 C29 C30 C30 C30 C29 C30 C29 
            builder.Add(0b1010010110110); // 2016 C30 C29 C30 C29 C29 C30 C29 C30 C30 C29 C30 C30 
            builder.Add(0b0101001010111); // 2017 C29 C30 C29 C30 C29 C29 L30 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0101001010110); // 2018 C29 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 
            builder.Add(0b1010100100110); // 2019 C30 C29 C30 C29 C30 C29 C29 C30 C29 C29 C30 C30 
            builder.Add(0b0111010010101); // 2020 C29 C30 C30 C30 L29 C30 C29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0110101010100); // 2021 C29 C30 C30 C29 C30 C29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010110101010); // 2022 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0100110110101); // 2023 C29 C30 L29 C29 C30 C30 C29 C30 C30 C29 C30 C29 C30 
            builder.Add(0b0100101101100); // 2024 C29 C30 C29 C29 C30 C29 C30 C30 C29 C30 C30 C29 
            builder.Add(0b1010010101110); // 2025 C30 C29 C30 C29 C29 C30 L29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1010010011100); // 2026 C30 C29 C30 C29 C29 C30 C29 C29 C30 C30 C30 C29 
            builder.Add(0b1101001001100); // 2027 C30 C30 C29 C30 C29 C29 C30 C29 C29 C30 C30 C29 
            builder.Add(0b1110100100110); // 2028 C30 C30 C30 C29 C30 L29 C29 C30 C29 C29 C30 C30 C29 
            builder.Add(0b1101010100110); // 2029 C30 C30 C29 C30 C29 C30 C29 C30 C29 C29 C30 C30 
            builder.Add(0b0101101010100); // 2030 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b0110101101010); // 2031 C29 C30 C30 L29 C30 C29 C30 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1001011011010); // 2032 C30 C29 C29 C30 C29 C30 C30 C29 C30 C30 C29 C30 
            builder.Add(0b0100101011101); // 2033 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 C30 L29 C30 
            builder.Add(0b0100101011010); // 2034 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 C29 C30 
            builder.Add(0b1010010011010); // 2035 C30 C29 C30 C29 C29 C30 C29 C29 C30 C30 C29 C30 
            builder.Add(0b1101001001011); // 2036 C30 C30 C29 C30 C29 C29 L30 C29 C29 C30 C29 C30 C30 
            builder.Add(0b1101001001010); // 2037 C30 C30 C29 C30 C29 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b1101010100100); // 2038 C30 C30 C29 C30 C29 C30 C29 C30 C29 C29 C30 C29 
            builder.Add(0b1101101010100); // 2039 C30 C30 C29 C30 C30 L29 C30 C29 C30 C29 C30 C29 C29 
            builder.Add(0b1011010110100); // 2040 C30 C29 C30 C30 C29 C30 C29 C30 C30 C29 C30 C29 
            builder.Add(0b0101011011010); // 2041 C29 C30 C29 C30 C29 C30 C30 C29 C30 C30 C29 C30 
            builder.Add(0b0100101011011); // 2042 C29 C30 L29 C29 C30 C29 C30 C29 C30 C30 C29 C30 C30 
            builder.Add(0b0100100110110); // 2043 C29 C30 C29 C29 C30 C29 C29 C30 C30 C29 C30 C30 
            builder.Add(0b1010010010111); // 2044 C30 C29 C30 C29 C29 C30 C29 L29 C30 C29 C30 C30 C30 
            builder.Add(0b1010010010110); // 2045 C30 C29 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 
            builder.Add(0b1010101001010); // 2046 C30 C29 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b1011010100101); // 2047 C30 C29 C30 C30 C29 L30 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b0110110100100); // 2048 C29 C30 C30 C29 C30 C30 C29 C30 C29 C29 C30 C29 
            builder.Add(0b1010110110100); // 2049 C30 C29 C30 C29 C30 C30 C29 C30 C30 C29 C30 C29 
            builder.Add(0b0101010110110); // 2050 C29 C30 C29 L30 C29 C30 C29 C30 C30 C29 C30 C30 C29 
            builder.Add(0b1001001101110); // 2051 C30 C29 C29 C30 C29 C29 C30 C30 C29 C30 C30 C30 
            builder.Add(0b0100100101111); // 2052 C29 C30 C29 C29 C30 C29 C29 C30 L29 C30 C30 C30 C30 
            builder.Add(0b0100100101110); // 2053 C29 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0110010010110); // 2054 C29 C30 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 
            builder.Add(0b0110101001010); // 2055 C29 C30 C30 C29 C30 C29 L30 C29 C29 C30 C29 C30 C29 
            builder.Add(0b1110101001010); // 2056 C30 C30 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b0110101010100); // 2057 C29 C30 C30 C29 C30 C29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010101101100); // 2058 C30 C29 C30 C29 L30 C29 C30 C30 C29 C30 C30 C29 C29 
            builder.Add(0b1010101011100); // 2059 C30 C29 C30 C29 C30 C29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1001001011100); // 2060 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1100100101110); // 2061 C30 C30 C29 L29 C30 C29 C29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1100100101100); // 2062 C30 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 C29 
            builder.Add(0b1101010010101); // 2063 C30 C30 C29 C30 C29 C30 C29 L29 C30 C29 C30 C29 C30 
            builder.Add(0b1101010010100); // 2064 C30 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 C29 
            builder.Add(0b1101101001010); // 2065 C30 C30 C29 C30 C30 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b0101101010101); // 2066 C29 C30 C29 C30 C30 L29 C30 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0101011010100); // 2067 C29 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010011011010); // 2068 C30 C29 C30 C29 C29 C30 C30 C29 C30 C30 C29 C30 
            builder.Add(0b0101001011101); // 2069 C29 C30 C29 C30 L29 C29 C30 C29 C30 C30 C30 C29 C30 
            builder.Add(0b0101001011010); // 2070 C29 C30 C29 C30 C29 C29 C30 C29 C30 C30 C29 C30 
            builder.Add(0b1010100101011); // 2071 C30 C29 C30 C29 C30 C29 C29 C30 L29 C30 C29 C30 C30 
            builder.Add(0b1010100101010); // 2072 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b1011010010100); // 2073 C30 C29 C30 C30 C29 C30 C29 C29 C30 C29 C30 C29 
            builder.Add(0b1011010101010); // 2074 C30 C29 C30 C30 C29 C30 L29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010110101010); // 2075 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0101010110100); // 2076 C29 C30 C29 C30 C29 C30 C29 C30 C30 C29 C30 C29 
            builder.Add(0b1010010111010); // 2077 C30 C29 C30 C29 L29 C30 C29 C30 C30 C30 C29 C30 C29 
            builder.Add(0b1010010110110); // 2078 C30 C29 C30 C29 C29 C30 C29 C30 C30 C29 C30 C30 
            builder.Add(0b0101001010110); // 2079 C29 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 
            builder.Add(0b1010100100111); // 2080 C30 C29 C30 L29 C30 C29 C29 C30 C29 C29 C30 C30 C30 
            builder.Add(0b0110100100110); // 2081 C29 C30 C30 C29 C30 C29 C29 C30 C29 C29 C30 C30 
            builder.Add(0b0111001010011); // 2082 C29 C30 C30 C30 C29 C29 C30 L29 C30 C29 C29 C30 C30 
            builder.Add(0b0110101010100); // 2083 C29 C30 C30 C29 C30 C29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010110101010); // 2084 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0100110110101); // 2085 C29 C30 C29 C29 C30 L30 C29 C30 C30 C29 C30 C29 C30 
            builder.Add(0b0100101101100); // 2086 C29 C30 C29 C29 C30 C29 C30 C30 C29 C30 C30 C29 
            builder.Add(0b1010010101110); // 2087 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0101001001110); // 2088 C29 C30 C29 C30 L29 C29 C30 C29 C29 C30 C30 C30 C29 
            builder.Add(0b1101000101100); // 2089 C30 C30 C29 C30 C29 C29 C29 C30 C29 C30 C30 C29 
            builder.Add(0b1110100100110); // 2090 C30 C30 C30 C29 C30 C29 C29 C30 L29 C29 C30 C30 C29 
            builder.Add(0b1101010100100); // 2091 C30 C30 C29 C30 C29 C30 C29 C30 C29 C29 C30 C29 
            builder.Add(0b1101101010100); // 2092 C30 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b0110101101010); // 2093 C29 C30 C30 C29 C30 C29 L30 C30 C29 C30 C29 C30 C29 
            builder.Add(0b0101011011010); // 2094 C29 C30 C29 C30 C29 C30 C30 C29 C30 C30 C29 C30 
            builder.Add(0b0100101011100); // 2095 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1010010011101); // 2096 C30 C29 C30 C29 L29 C30 C29 C29 C30 C30 C30 C29 C30 
            builder.Add(0b1010001011010); // 2097 C30 C29 C30 C29 C29 C29 C30 C29 C30 C30 C29 C30 
            builder.Add(0b1101000101010); // 2098 C30 C30 C29 C30 C29 C29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b1101100100101); // 2099 C30 C30 L29 C30 C30 C29 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b1101010100100); // 2100 C30 C30 C29 C30 C29 C30 C29 C30 C29 C29 C30 C29 
            builder.Add(0b1101101010010); // 2101 C30 C30 C29 C30 C30 C29 C30 L29 C30 C29 C29 C30 C29 
            builder.Add(0b1011010110100); // 2102 C30 C29 C30 C30 C29 C30 C29 C30 C30 C29 C30 C29 
            builder.Add(0b0101010111010); // 2103 C29 C30 C29 C30 C29 C30 C29 C30 C30 C30 C29 C30 
            builder.Add(0b0100101011011); // 2104 C29 C30 C29 C29 C30 L29 C30 C29 C30 C30 C29 C30 C30 
            builder.Add(0b0100100110110); // 2105 C29 C30 C29 C29 C30 C29 C29 C30 C30 C29 C30 C30 
            builder.Add(0b1010010010110); // 2106 C30 C29 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 
            builder.Add(0b1101001001011); // 2107 C30 C30 C29 C30 L29 C29 C30 C29 C29 C30 C29 C30 C30 
            builder.Add(0b1010101001010); // 2108 C30 C29 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b1011010100101); // 2109 C30 C29 C30 C30 C29 C30 C29 C30 C29 L29 C30 C29 C30 
            builder.Add(0b0110110100100); // 2110 C29 C30 C30 C29 C30 C30 C29 C30 C29 C29 C30 C29 
            builder.Add(0b1010110101100); // 2111 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 C30 C29 
            builder.Add(0b0101010110110); // 2112 C29 C30 C29 C30 C29 C30 L29 C30 C30 C29 C30 C30 C29 
            builder.Add(0b1001001101110); // 2113 C30 C29 C29 C30 C29 C29 C30 C30 C29 C30 C30 C30 
            builder.Add(0b0100100101110); // 2114 C29 C30 C29 C29 C30 C29 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0110010010111); // 2115 C29 C30 C30 C29 L29 C30 C29 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0101010010110); // 2116 C29 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 C30 
            builder.Add(0b0110101001010); // 2117 C29 C30 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b0110110100101); // 2118 C29 C30 C30 L29 C30 C30 C29 C30 C29 C29 C30 C29 C30 
            builder.Add(0b0110101010100); // 2119 C29 C30 C30 C29 C30 C29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010101101010); // 2120 C30 C29 C30 C29 C30 C29 C30 L30 C29 C30 C29 C30 C29 
            builder.Add(0b1010101011010); // 2121 C30 C29 C30 C29 C30 C29 C30 C29 C30 C30 C29 C30 
            builder.Add(0b0101001011100); // 2122 C29 C30 C29 C30 C29 C29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1100100101110); // 2123 C30 C30 C29 C29 C30 L29 C29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1010100101100); // 2124 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 C30 C29 
            builder.Add(0b1101010010100); // 2125 C30 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 C29 
            builder.Add(0b1110101001010); // 2126 C30 C30 C30 C29 L30 C29 C30 C29 C29 C30 C29 C30 C29 
            builder.Add(0b1101100101010); // 2127 C30 C30 C29 C30 C30 C29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0101101010101); // 2128 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 L29 C30 
            builder.Add(0b0101011010100); // 2129 C29 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010011011010); // 2130 C30 C29 C30 C29 C29 C30 C30 C29 C30 C30 C29 C30 
            builder.Add(0b0101001011101); // 2131 C29 C30 C29 C30 C29 C29 L30 C29 C30 C30 C30 C29 C30 
            builder.Add(0b0101001011010); // 2132 C29 C30 C29 C30 C29 C29 C30 C29 C30 C30 C29 C30 
            builder.Add(0b1010100011010); // 2133 C30 C29 C30 C29 C30 C29 C29 C29 C30 C30 C29 C30 
            builder.Add(0b1101010010101); // 2134 C30 C30 C29 C30 C29 L30 C29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b1011001010100); // 2135 C30 C29 C30 C30 C29 C29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1011010101010); // 2136 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0101011010101); // 2137 C29 C30 L29 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0101010110100); // 2138 C29 C30 C29 C30 C29 C30 C29 C30 C30 C29 C30 C29 
            builder.Add(0b1010010111010); // 2139 C30 C29 C30 C29 C29 C30 C29 L30 C30 C30 C29 C30 C29 
            builder.Add(0b1010010110110); // 2140 C30 C29 C30 C29 C29 C30 C29 C30 C30 C29 C30 C30 
            builder.Add(0b0101001010110); // 2141 C29 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 
            builder.Add(0b1010100010111); // 2142 C30 C29 C30 C29 C30 L29 C29 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0110100010110); // 2143 C29 C30 C30 C29 C30 C29 C29 C29 C30 C29 C30 C30 
            builder.Add(0b0111001010010); // 2144 C29 C30 C30 C30 C29 C29 C30 C29 C30 C29 C29 C30 
            builder.Add(0b1011010101010); // 2145 C30 C29 C30 C30 L29 C30 C29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b0110101101010); // 2146 C29 C30 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 
            builder.Add(0b0010110110101); // 2147 C29 C29 C30 C29 C30 C30 C29 C30 C30 C29 C30 L29 C30 
            builder.Add(0b0100101101100); // 2148 C29 C30 C29 C29 C30 C29 C30 C30 C29 C30 C30 C29 
            builder.Add(0b1010010101110); // 2149 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0101000101110); // 2150 C29 C30 C29 C30 C29 C29 L29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1101000101100); // 2151 C30 C30 C29 C30 C29 C29 C29 C30 C29 C30 C30 C29 
            builder.Add(0b1110100010110); // 2152 C30 C30 C30 C29 C30 C29 C29 C29 C30 C29 C30 C30 
            builder.Add(0b0110101010010); // 2153 C29 C30 C30 C29 C30 L29 C30 C29 C30 C29 C29 C30 C29 
            builder.Add(0b1101101010010); // 2154 C30 C30 C29 C30 C30 C29 C30 C29 C30 C29 C29 C30 
            builder.Add(0b0101101101010); // 2155 C29 C30 C29 C30 C30 C29 C30 C30 C29 C30 C29 C30 
            builder.Add(0b0010101101101); // 2156 C29 C29 C30 L29 C30 C29 C30 C30 C29 C30 C30 C29 C30 
            builder.Add(0b0010101011100); // 2157 C29 C29 C30 C29 C30 C29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1010001011101); // 2158 C30 C29 C30 C29 C29 C29 C30 L29 C30 C30 C30 C29 C30 
            builder.Add(0b1010001011010); // 2159 C30 C29 C30 C29 C29 C29 C30 C29 C30 C30 C29 C30 
            builder.Add(0b1101000101010); // 2160 C30 C30 C29 C30 C29 C29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b1101010010101); // 2161 C30 C30 C29 C30 C29 C30 L29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b1011010100100); // 2162 C30 C29 C30 C30 C29 C30 C29 C30 C29 C29 C30 C29 
            builder.Add(0b1101011010010); // 2163 C30 C30 C29 C30 C29 C30 C30 C29 C30 C29 C29 C30 
            builder.Add(0b0101101011010); // 2164 C29 C30 C29 C30 L30 C29 C30 C29 C30 C30 C29 C30 C29 
            builder.Add(0b0101010110110); // 2165 C29 C30 C29 C30 C29 C30 C29 C30 C30 C29 C30 C30 
            builder.Add(0b0010101011011); // 2166 C29 C29 C30 C29 C30 C29 C30 C29 C30 C30 L29 C30 C30 
            builder.Add(0b0100010110110); // 2167 C29 C30 C29 C29 C29 C30 C29 C30 C30 C29 C30 C30 
            builder.Add(0b1010001010110); // 2168 C30 C29 C30 C29 C29 C29 C30 C29 C30 C29 C30 C30 
            builder.Add(0b1010100101011); // 2169 C30 C29 C30 C29 C30 C29 L29 C30 C29 C30 C29 C30 C30 
            builder.Add(0b1010100101010); // 2170 C30 C29 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b1011010010100); // 2171 C30 C29 C30 C30 C29 C30 C29 C29 C30 C29 C30 C29 
            builder.Add(0b1011010101010); // 2172 C30 C29 C30 C30 C29 L30 C29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010110101010); // 2173 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0101010110110); // 2174 C29 C30 C29 C30 C29 C30 C29 C30 C30 C29 C30 C30 
            builder.Add(0b0010010110111); // 2175 C29 C29 C30 L29 C29 C30 C29 C30 C30 C29 C30 C30 C30 
            builder.Add(0b0100010101110); // 2176 C29 C30 C29 C29 C29 C30 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0110001010111); // 2177 C29 C30 C30 C29 C29 C29 C30 L29 C30 C29 C30 C30 C30 
            builder.Add(0b0101001010110); // 2178 C29 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 
            builder.Add(0b0110100101010); // 2179 C29 C30 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0110110010101); // 2180 C29 C30 C30 C29 C30 C30 L29 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0101101010100); // 2181 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010101101010); // 2182 C30 C29 C30 C29 C30 C29 C30 C30 C29 C30 C29 C30 
            builder.Add(0b0101001101101); // 2183 C29 C30 C29 C30 L29 C29 C30 C30 C29 C30 C30 C29 C30 
            builder.Add(0b0100101011100); // 2184 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1010010101110); // 2185 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 C30 
            builder.Add(0b0101001010110); // 2186 C29 C30 L29 C30 C29 C29 C30 C29 C30 C29 C30 C30 C29 
            builder.Add(0b1101001010100); // 2187 C30 C30 C29 C30 C29 C29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1110100101010); // 2188 C30 C30 C30 C29 C30 C29 L29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1101010101010); // 2189 C30 C30 C29 C30 C29 C30 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0101101010100); // 2190 C29 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010101101010); // 2191 C30 C29 C30 C29 C30 L29 C30 C30 C29 C30 C29 C30 C29 
            builder.Add(0b1010011011010); // 2192 C30 C29 C30 C29 C29 C30 C30 C29 C30 C30 C29 C30 
            builder.Add(0b0100101011100); // 2193 C29 C30 C29 C29 C30 C29 C30 C29 C30 C30 C30 C29 
            builder.Add(0b1010010101011); // 2194 C30 C29 C30 L29 C29 C30 C29 C30 C29 C30 C29 C30 C30 
            builder.Add(0b1010010011010); // 2195 C30 C29 C30 C29 C29 C30 C29 C29 C30 C30 C29 C30 
            builder.Add(0b1101001001011); // 2196 C30 C30 C29 C30 C29 C29 C30 L29 C29 C30 C29 C30 C30 
            builder.Add(0b1011001010010); // 2197 C30 C29 C30 C30 C29 C29 C30 C29 C30 C29 C29 C30 
            builder.Add(0b1011010101010); // 2198 C30 C29 C30 C30 C29 C30 C29 C30 C29 C30 C29 C30 
            builder.Add(0b0101011010101); // 2199 C29 C30 C29 C30 C29 C30 L30 C29 C30 C29 C30 C29 C30 
            RiCountOfYueTable = builder.MoveToImmutable();
        }

    }
}
